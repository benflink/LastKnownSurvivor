using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadbuttScript : MonoBehaviour
{
    public Rigidbody head;
    public Rigidbody hips;
    public bool readyhead = false;
    public bool isWaiting = false;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        head = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (playerController.canMove == true)
        {

            if (isWaiting == false)
            {
                if (Input.GetAxis("Headbutt") > 0)
                {
                    Debug.Log("HEADING!");
                    readyhead = true;
                }
                else if (readyhead == true)
                {
                    head.AddRelativeForce(new Vector3(0, 0, 2000));
                    hips.AddRelativeForce(new Vector3(0, -2000, 0));
                    readyhead = false;
                    StartCoroutine(waiter());
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