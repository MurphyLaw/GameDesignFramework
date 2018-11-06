using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float sensitivityY = 1.0f;

    [SerializeField]
    private Camera playerCamera;

    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent <PlayerMotor>();
    }

    void Update()
    {
        //Calculate our movement velocity as a 3d Vector
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 movHorizontal = transform.right * xMov;
        Vector3 movVertical = transform.forward * zMov;

        // Final Movement Vector
        Vector3 velocity = (movHorizontal + movVertical).normalized * speed;

        // Apply Movement
        motor.Move(velocity);

        // float yRot = Input.GetAxisRaw("Mouse X");
        float yRot = playerCamera.transform.eulerAngles.y;

        Vector3 rot = new Vector3(0f, yRot, 0f);

        motor.Rotate(rot);
    }

}
