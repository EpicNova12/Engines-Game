using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
   /* public float horizontalSensitivity;
    public float verticalSensitivity;

    public Transform orientation;

    float xRot;
    float yRot;*/

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
       /* float mouseX = Input.GetAxis("Mouse X") * horizontalSensitivity * Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSensitivity * Time.fixedDeltaTime;

        yRot += mouseX;
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot,-90.0f,90.0f);

        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        orientation.rotation = Quaternion.Euler(0, yRot, 0);*/

    }
}

//Camera and movement code from
//https://youtu.be/f473C43s8nE