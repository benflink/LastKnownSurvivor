using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public PlayerController playerController;
    public float rotationSpeed = 1;
    public Transform root;

    float mouseX, mouseY;

    public float stomachOffset;

    public ConfigurableJoint hipJoint, stomachJoint;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CamControl();
    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -25, 25);

        Quaternion rootRotation = Quaternion.Euler(0, mouseX, mouseY);
        root.rotation = rootRotation;
        if (playerController.canMove == true)
        {
            

            //hipJoint.targetRotation = Quaternion.Euler(0, -mouseX, 0);
            stomachJoint.targetRotation = Quaternion.Euler(-mouseY + stomachOffset, 0, 0);
        }
    }
}
