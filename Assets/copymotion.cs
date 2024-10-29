using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copymotion : MonoBehaviour
{

    public Transform target;
    private ConfigurableJoint joint;
    public PlayerController playerController;

    private Quaternion startingRotation;

    void Start()
    {
        joint = GetComponent<ConfigurableJoint>();
        startingRotation = transform.rotation;
    }

    void Update()
    {
        if (playerController && playerController.canMove == true)
        {
            joint.SetTargetRotationLocal(target.rotation, startingRotation);
        }
        if (!playerController)
        {
            joint.SetTargetRotationLocal(target.rotation, startingRotation);
        }
    }
}
