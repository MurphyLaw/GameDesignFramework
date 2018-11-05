using UnityEngine;

[RequireComponent(typeof(ThirdPersonCameraMotor))]
public class ThirdPersonCameraControllerScript : MonoBehaviour {

    [SerializeField]
    private Transform lookAt;
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float distance = 10.0f;
    [SerializeField]
    private bool isInverted = true;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    [SerializeField]
    private float sensitivityX = 2.0f;
    [SerializeField]
    private float sensitivityY = 1.0f;


    private ThirdPersonCameraMotor cameraMotor;

    void Start()
    {
        cameraMotor = GetComponent<ThirdPersonCameraMotor>();
    }

    void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");

        Vector3 dir = new Vector3(0, 0, -distance);

        int orientation = isInverted ? -1 : 1;
        Quaternion rotation = Quaternion.Euler(orientation * currentY * sensitivityY, currentX * sensitivityX, 0);

        Vector3 position = lookAt.position + rotation * dir;

        cameraMotor.LookAt(lookAt, position);
    }
}
