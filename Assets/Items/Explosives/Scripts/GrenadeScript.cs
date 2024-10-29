using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float explosionForce = 5f; // Adjust as needed
    public float explosionRadius = 1f;   // Adjust as needed

    private bool exploded = false;

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag != "GroundToJump")
        {
            if (!exploded)
            {
                StartCoroutine(ExplodeAfterDelay());
                exploded = true;
            }
        }
    }

    IEnumerator ExplodeAfterDelay()
    {
        yield return new WaitForSeconds(5f); // Wait for 3 seconds

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
