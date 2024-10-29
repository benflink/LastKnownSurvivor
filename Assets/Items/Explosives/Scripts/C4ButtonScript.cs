using UnityEngine;

public class ButtonActivator : MonoBehaviour
{
    public GameObject c4;  // Reference to the C4 GameObject

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
        // Check if the collided object has a C4 component
        if (1 == 1)
        {
            Debug.Log("Activate");
            C4 c4Component = c4.GetComponent<C4>();
            if (c4Component != null)
            {
                
                c4Component.Activate();
                Destroy(gameObject);
            }
        }
    }
}
