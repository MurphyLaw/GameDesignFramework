using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 vel)
    {
        velocity = vel;
    }

    public void Rotate(Vector3 rot)
    {
        rotation = rot;
    }

    private void FixedUpdate()
    {
        performMovement();
        performRotation();
    }

    void performMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    void performRotation()
    {
        if (rotation != Vector3.zero)
        {
            rb.MoveRotation(Quaternion.Euler(rotation).normalized);
        }
    }
}
