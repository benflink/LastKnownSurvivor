using UnityEngine;
using System.Collections;

public class C4 : MonoBehaviour
{
    public float explosionForce = 1000f; // Adjust as needed
    public float explosionRadius = 5f;   // Adjust as needed
    public float detonationTime = 3f;    // Time in seconds before detonation

    private bool exploded = false;

    private Vector3 initialPosition;  // Store initial position of C4

    void Start()
    {
        // Store initial position
        initialPosition = transform.position;

        // Ensure the C4 is not triggered immediately upon start
        exploded = false;
    }

    public void Activate()
    {
        if (!exploded)
        {
            exploded = true;
            StartCoroutine(ExplodeAfterDelay());
        }
    }
    

    IEnumerator ExplodeAfterDelay()
    {
        yield return new WaitForSeconds(detonationTime); 

        // Perform explosion physics
        Vector3 explosionPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // Apply explosion force to rigidbody
                rb.AddExplosionForce(explosionForce, explosionPosition, explosionRadius, 1f, ForceMode.Impulse);
            }
        }

        // Optional: Instantiate explosion VFX or sound

        // Destroy the grenade object after explosion
        Destroy(gameObject);
    }
}
