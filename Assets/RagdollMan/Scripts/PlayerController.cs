using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float strafeSpeed;
    public float jumpForce;
    public Animator animator;

    public Rigidbody hips;
    public Rigidbody rShoulder;
    public Rigidbody lShoulder;
    public bool isGrounded;
    public int readypunch = 0;
    public int lreadypunch = 0;
    public bool rcoroutinestarted = false;
    public int rightpforce = 1;
    public bool lcoroutinestarted = false;
    public int leftpforce = 1;
    public CollisionCheck[] collisionCheckers; // Array of CollisionCheck scripts
    public bool canMove;
    private bool isRightPunchOnCooldown = false;
    private bool isLeftPunchOnCooldown = false;
    private float punchCooldownTime = 0.5f;


    void Start()
    {
        hips = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
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

        if (canMove)
        {

            float moveFB = Input.GetAxis("Horizontal");
            float moveLR = Input.GetAxis("Vertical");

            if (moveLR > 0.3)
            {
                if (Input.GetButton("Sprint"))
                {
                    hips.AddForce(hips.transform.forward * speed * 1.5f);
                    animator.SetBool("isWalk", true);
                    animator.SetBool("isRun", true);
                }
                else
                {
                    animator.SetBool("isWalk", true);
                    animator.SetBool("isRun", false);
                    hips.AddForce(hips.transform.forward * speed);
                }
            }
            else
            {
                animator.SetBool("isWalk", false);
                animator.SetBool("isRun", false);
            }

            if (moveLR < -0.3)
            {
                animator.SetBool("isBack", true);
                hips.AddForce(-hips.transform.forward * speed);
            }
            else
            {
                animator.SetBool("isBack", false);
            }

            if (moveFB > 0.3)
            {
                animator.SetBool("isSideLeft", true);
                hips.AddForce(hips.transform.right * strafeSpeed);
            }
            else
            {
                animator.SetBool("isSideLeft", false);
            }

            if (moveFB < -0.3)
            {
                animator.SetBool("isSideRight", true);
                hips.AddForce(-hips.transform.right * strafeSpeed);
            }
            else
            {
                animator.SetBool("isSideRight", false);
            }

            if (Input.GetAxis("RB") > 0)
            {
                if (isRightPunchOnCooldown == false)
                {
                    animator.SetBool("isRightPunch", true);
                    readypunch = 1;
                    if (rcoroutinestarted == false)
                    {
                        StartCoroutine(waiter());
                    }
                }
            }
            else if (readypunch == 1)
            {
                animator.SetBool("isRightPunch", false);
                rShoulder.AddRelativeForce(new Vector3(0, 0, 1000 * rightpforce));
                readypunch = 0;
                rightpforce = 1;
                isRightPunchOnCooldown = true;
                StartCoroutine(RightPunchCooldown());
            }
            else
            {
                animator.SetBool("isRightPunch", false);
                readypunch = 0;
                rcoroutinestarted = false;
                rightpforce = 1;
            }

            if (Input.GetAxis("LB") > 0)
            {
                if (isLeftPunchOnCooldown == false)
                {
                    animator.SetBool("isLeftPunch", true);
                    lreadypunch = 1;
                    if (lcoroutinestarted == false)
                    {
                        StartCoroutine(lwaiter());
                    }
                }

            }
            else if (lreadypunch == 1)
            {
                animator.SetBool("isLeftPunch", false);
                lShoulder.AddRelativeForce(new Vector3(0, 0, 1000 * leftpforce));
                lreadypunch = 0;
                leftpforce = 1;
                isLeftPunchOnCooldown = true;
                StartCoroutine(LeftPunchCooldown());
            }
            else
            {
                animator.SetBool("isLeftPunch", false);
                lreadypunch = 0;
                lcoroutinestarted = false;
                leftpforce = 1;
            }

            if (Input.GetAxis("Jump") > 0)
            {
                if (isGrounded)
                {
                    hips.AddForce(new Vector3(0, jumpForce, 0));
                    isGrounded = false;
                }
            }
        }
    }

    IEnumerator waiter()
    {
        rcoroutinestarted = true;
        //Rotate 90 deg
        if (readypunch == 1)
        {
            Debug.Log("One");
        }
        else
        {
            yield break;
        }

        
        if (readypunch == 1)
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }
        else
        {
            yield break;
        }
        if (readypunch == 1)
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }
        else
        {
            yield break;
        }
        if (readypunch == 1)
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }
        else
        {
            yield break;
        }
        if (readypunch == 1)
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }
        else
        {
            yield break;
        }
        if (readypunch == 1)
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }
        else
        {
            yield break;
        }

        if (readypunch == 1)
        {
            Debug.Log("Two");
            rightpforce = 3;
        }
        else
        {
            yield break;
        }

        
        if (readypunch == 1)
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }
        else
        {
            yield break;
        }
        if (readypunch == 1)
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }
        else
        {
            yield break;
        }
        if (readypunch == 1)
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }
        else
        {
            yield break;
        }
        if (readypunch == 1)
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }
        else
        {
            yield break;
        }
        if (readypunch == 1)
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }
        else
        {
            yield break;
        }

        if (readypunch == 1)
        {
            Debug.Log("Three");
            rightpforce = 5;
        }
        else
        {
            yield break;
        }

    }
    IEnumerator lwaiter()
    {
        lcoroutinestarted = true;
        //Rotate 90 deg
        if (lreadypunch == 1)
        {
            Debug.Log("lOne");
        }
        else
        {
            yield break;
        }

        
        if (lreadypunch == 1)
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }
        else
        {
            yield break;
        }
        if (lreadypunch == 1)
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }
        else
        {
            yield break;
        }
        if (lreadypunch == 1)
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }
        else
        {
            yield break;
        }
        if (lreadypunch == 1)
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }
        else
        {
            yield break;
        }
        if (lreadypunch == 1)
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }
        else
        {
            yield break;
        }

        if (lreadypunch == 1)
        {
            Debug.Log("lTwo");
            leftpforce = 3;
        }
        else
        {
            yield break;
        }

        
        if (lreadypunch == 1)
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }
        else
        {
            yield break;
        }
        if (lreadypunch == 1)
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }
        else
        {
            yield break;
        }
        if (lreadypunch == 1)
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }
        else
        {
            yield break;
        }
        if (lreadypunch == 1)
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }
        else
        {
            yield break;
        }
        if (lreadypunch == 1)
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }
        else
        {
            yield break;
        }

        if (lreadypunch == 1)
        {
            Debug.Log("lThree");
            leftpforce = 5;
        }
        else
        {
            yield break;
        }
    }

    IEnumerator RightPunchCooldown()
    {
        yield return new WaitForSeconds(punchCooldownTime);
        isRightPunchOnCooldown = false;
    }

    IEnumerator LeftPunchCooldown()
    {
        yield return new WaitForSeconds(punchCooldownTime);
        isLeftPunchOnCooldown = false;
    }
}


