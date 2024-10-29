using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour
{
    private bool hold;
    public KeyCode grabKey;
    public bool canGrab;
    public Animator animator;
    public bool RightHand;
    public Rigidbody hips;
    public bool isGrab = false;
    public PlayerController playerController;


    void Update()
    {
        if (playerController.canMove == true)
        {
            if (canGrab)
            {
                if (RightHand)
                {

                    if (Input.GetAxis("RT") > 0)
                    {
                        hold = true;
                        animator.SetBool("isRightGrab", true);
                        if (Input.GetAxis("Mouse Y") < -0.5)
                        {
                            if (isGrab == true)
                            {
                                hips.AddRelativeForce(new Vector3(0, 100, 0));
                            }
                        }
                    }
                    else
                    {
                        hold = false;
                        animator.SetBool("isRightGrab", false);
                        isGrab = false;
                        Destroy(GetComponent<FixedJoint>());
                    }
                }
                else
                {
                    if (Input.GetAxis("LT") > 0)
                    {
                        hold = true;
                        animator.SetBool("isLeftGrab", true);
                        if (Input.GetAxis("Mouse Y") < -0.5)
                        {
                            if (isGrab == true)
                            {
                                hips.AddRelativeForce(new Vector3(0, 100, 0));
                            }
                        }
                    }
                    else
                    {
                        hold = false;
                        animator.SetBool("isLeftGrab", false);
                        isGrab = false;
                        Destroy(GetComponent<FixedJoint>());
                    }
                }
            }
        }
        
        if (playerController.canMove == false)
        {
            Debug.Log("kooood");

        }


    }

    private void OnCollisionEnter(Collision col)
    {
        if (hold && col.transform.tag != "Player")
        {
            Rigidbody rb = col.transform.GetComponent<Rigidbody>();
            if (rb != null)
            {
                FixedJoint fj = transform.gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
                fj.connectedBody = rb;
                isGrab = false;
            }
            else
            {
                FixedJoint fj = transform.gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
                isGrab = true;

            }
        }
        
    }
    
}


