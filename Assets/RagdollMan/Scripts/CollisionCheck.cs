using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionCheck : MonoBehaviour
{
    public float health;
    public float targethealth;
    public ConfigurableJoint hips;
    public bool isHeal;
    public int powerofknock = 0;
    // Start is called before the first frame update
    void Start()
    {
        // nothing for now
    }

    // Update is called once per frame

    void OnCollisionEnter(Collision collision)
    {
        Vector3 velocity = collision.relativeVelocity;
        float velocitysum = Mathf.Abs(velocity.x) + Mathf.Abs(velocity.y) + Mathf.Abs(velocity.z);
        Vector3 normal = collision.GetContact(0).normal;
        if (velocitysum > 5)
        {
            health = health - velocitysum;
        }
        if (health < 0)
        {
            JointDrive jointDrive = hips.angularXDrive;
            jointDrive.positionSpring = 0f;
            hips.angularXDrive = jointDrive;

            JointDrive jointDrive2 = hips.angularYZDrive;
            jointDrive2.positionSpring = 0f;
            hips.angularYZDrive = jointDrive2;

            if (health < -90)
            {
                powerofknock = 3;
                StartCoroutine(waiter());
            }
            else if (health < -45)
            {
                powerofknock = 2;
                StartCoroutine(waiter());
            }
            else
            {
                powerofknock = 1;
                StartCoroutine(waiter());
            }



            //joint.angularXDrive = jointDrive;


        }
    }

    IEnumerator waiter()
    {
        if (powerofknock == 1)
        {
            //Debug.Log("POWER 1");
            yield return new WaitForSecondsRealtime(10);
            JointDrive jointDrive = hips.angularXDrive;
            jointDrive.positionSpring = 1500f;
            hips.angularXDrive = jointDrive;

            JointDrive jointDrive2 = hips.angularYZDrive;
            jointDrive2.positionSpring = 1500f;
            hips.angularYZDrive = jointDrive2;
            powerofknock = 0;
            
        }
        if (powerofknock == 2)
        {
            //Debug.Log("POWER 2");
            yield return new WaitForSecondsRealtime(15);
            JointDrive jointDrive = hips.angularXDrive;
            jointDrive.positionSpring = 1500f;
            hips.angularXDrive = jointDrive;

            JointDrive jointDrive2 = hips.angularYZDrive;
            jointDrive2.positionSpring = 1500f;
            hips.angularYZDrive = jointDrive2;
            powerofknock = 0;
        }
        if (powerofknock == 3)
        {
            //Debug.Log("POWER 3");
            yield return new WaitForSecondsRealtime(20);
            JointDrive jointDrive = hips.angularXDrive;
            jointDrive.positionSpring = 1500f;
            hips.angularXDrive = jointDrive;

            JointDrive jointDrive2 = hips.angularYZDrive;
            jointDrive2.positionSpring = 1500f;
            hips.angularYZDrive = jointDrive2;
            powerofknock = 0;
        }
    }

    IEnumerator healer()
    {
        isHeal = true;
        if (health < targethealth)
        {
            health = health + 20;
        }
        yield return new WaitForSecondsRealtime(1);
        isHeal = false;
    }

    private void FixedUpdate()
    {
        if (isHeal == false)
        {
            StartCoroutine(healer());
        }
    }

}
