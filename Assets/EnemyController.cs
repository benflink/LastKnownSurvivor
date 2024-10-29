using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;        // Movement speed of the enemy
    public float attackRange = 1.5f;    // Range within which the enemy attacks
    public float knockbackForce = 10f;  // Force to push the player back when attacking
    public float attackCooldown = 2f;
    public float rotationSpeed = 5f;// Cooldown between attacks
    public LayerMask playerLayer;       // Layer where the player object is placed

    public Transform player;           // Reference to the player's transform
    public Rigidbody enemyRb;
    public Transform root; 
    private bool canAttack = true;

    public CollisionCheck[] collisionCheckers; // Array of CollisionCheck scripts
    public bool canMove;
    
    // Flag to check if the enemy can attack

    void Start()
    {
        // Find the player object by tag (you can modify this to find by other means)
        //player = GameObject.FindGameObjectWithTag("Player").transform;

        // Get the enemy's rigidbody component
        enemyRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        canMove = true;

        // Check all CollisionCheck scripts
        foreach (CollisionCheck checker in collisionCheckers)
        {
            if (checker.powerofknock != 0)
            {
                canMove = false;
                break; // No need to continue checking if one is found
            }
        }
        // Check if player is within attack range
        if (canMove)
        {
            if (Vector3.Distance(transform.position, player.position) <= attackRange && canAttack)
            {
                // Perform attack (knockback the player)
                AttackPlayer();
            }
            else
            {
                // Move towards the player if not in attack range
                MoveTowardsPlayer();
            }
        }
    }

    void MoveTowardsPlayer()
    {
        // Calculate direction towards the player
        Vector3 moveDirection = new Vector3(player.position.x - transform.position.x, 0, player.position.z - transform.position.z);


        // Rotate the enemy to face the player smoothly
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        root.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed);

        // Move the enemy using AddForce based on player's position relative to the enemy
        enemyRb.AddForce(enemyRb.transform.forward * moveSpeed * 1.5f);
    }


    void AttackPlayer()
    {

        Debug.Log("ATTACKING!!!!");
        // Apply knockback force to the player
        Vector3 knockbackDirection = (player.position - transform.position).normalized;
        player.GetComponent<Rigidbody>().AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);

        // Set cooldown to prevent continuous attacks
        canAttack = false;
        Invoke(nameof(ResetAttack), attackCooldown);
        
    }

    void ResetAttack()
    {
        // Reset attack cooldown
        canAttack = true;
    }
}
