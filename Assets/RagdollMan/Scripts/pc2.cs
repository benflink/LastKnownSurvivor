using UnityEngine;

public class pc2 : MonoBehaviour
{
    public float speed = 10.0f;

    private CharacterController player;

    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    void Update()
    {
        float moveFB = Input.GetAxis("Vertical") * speed;
        float moveLR = Input.GetAxis("Horizontal") * speed;

        Vector3 movement = new Vector3(0, 0, moveFB);
        movement = transform.rotation * movement;

        player.Move(movement * Time.deltaTime);
        transform.Rotate(0, moveLR, 0);
    }
}
