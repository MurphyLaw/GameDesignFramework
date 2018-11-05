using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraMotor : MonoBehaviour {
    
    private Transform camTransform;

    private Transform objectLook;
    private Vector3 objectPosition = Vector3.zero;

    private void Start()
    {
        camTransform = transform;
    }

    public void LookAt(Transform lookAt, Vector3 position)
    {
        objectLook = lookAt;
        objectPosition = position;
    }

    private void FixedUpdate()
    {
        performLook();
    }

    void performLook()
    {
        if (objectPosition != Vector3.zero)
        {
            camTransform.position = objectPosition;
            camTransform.LookAt(objectLook.position);
        }
    }
}
