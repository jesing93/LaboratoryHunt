using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Variables
    [Header("Camera sensibility")]
    public float sensX;
    public float sensY;
    private float xRotation;
    private float yRotation;
    private bool FPSMode;

    private void FixedUpdate()
    {
        //Get inputs
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        if (FPSMode)
        {
            xRotation = Mathf.Clamp(xRotation, -30f, 23f);
        }
        else
        {
            xRotation = Mathf.Clamp(xRotation, 0f, 45f);
        }

        //Rotate camera and orientations smoothly
        Quaternion targetXRotation = Quaternion.Euler(xRotation, yRotation, 0);
        transform.parent.rotation = Quaternion.Lerp(transform.parent.rotation, targetXRotation, Time.deltaTime * 10);

        //Quaternion targetYRotation = Quaternion.Euler(0, yRotation, 0);
        //PlayerController.instance.Orientation.rotation = Quaternion.Lerp(PlayerController.instance.Orientation.rotation, targetYRotation, Time.deltaTime * 5);

        //Rotate the player instead of the camera
        PlayerController.instance.Orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    public void SwitchToTPS() {
        transform.localPosition = new Vector3(0.75f, 0.7f, -1.5f);
        FPSMode = false;
    }

    public void SwitchToFPS()
    {
        transform.localPosition = new Vector3(0.1f, 0f, 0.1f);
        FPSMode = true;
    }
}
