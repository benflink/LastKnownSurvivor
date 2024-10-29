using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stormchecker : MonoBehaviour
{
    public Collider Zone;
    public GameObject Myself;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {
        // Destroy everything that leaves the trigger
        Destroy(Myself);
    }
}
