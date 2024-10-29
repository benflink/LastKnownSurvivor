using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickScript : MonoBehaviour
{
    public Rigidbody leg;
    public Rigidbody hips;
    public bool readykick = false;
    public bool isWaiting = false;
    public bool isRightLeg = false;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        leg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (playerController.canMove == true)
        {
            if (isRightLeg)
            {
                if (isWaiting == false)
                {
                    if (Input.GetAxis("Kick") > 0)
                    {
                        readykick = true;
                    }
                    else if (readykick == true)
                    {
                        leg.AddRelativeForce(new Vector3(8000, 0, 0));
                        hips.AddRelativeForce(new Vector3(0, -5000, 0));
                        readykick = false;
                        StartCoroutine(waiter());
                    }
                }
            }
            if (!isRightLeg)
            {
                if (isWaiting == false)
                {
                    if (Input.GetAxis("LKick") > 0)
                    {
                        readykick = true;
                    }
                    else if (readykick == true)
                    {
                        leg.AddRelativeForce(new Vector3(-8000, 0, 0));
                        hips.AddRelativeForce(new Vector3(0, -5000, 0));
                        readykick = false;
                        StartCoroutine(waiter());
                    }
                }
            }
        }
    }

    IEnumerator waiter()
    {
        isWaiting = true;
        yield return new WaitForSecondsRealtime(1);
        isWaiting = false;
        yield break;
    }
}
