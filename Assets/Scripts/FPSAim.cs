using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that controls the movement of the camera
/// </summary>
public class FPSAim : MonoBehaviour
{
    /// <summary>
    /// Definition of variables
    /// </summary>
    public bool invertedMouse;
    public float sensitivity = 1.0f;
    public float smoothing = 1.0f;
    public GameObject playerObject;
    private Vector2 cameraLook;
    private Vector2 smoothVector;

    /// <summary>
    /// Initialization of variables
    /// </summary>
	void Start () {
        playerObject = this.transform.parent.gameObject;
        invertedMouse = false;
	}

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update () 
    {
        //The values of the x-axis and y-axis are obtained, and then interpolated
        var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothVector.x = Mathf.Lerp(smoothVector.x, mouseDelta.x, 1f / smoothing);
        smoothVector.y = Mathf.Lerp(smoothVector.y, mouseDelta.y, 1f / smoothing);

        //Increase the value of cameraLook according to the smoothVector
        cameraLook += smoothVector;

        //Calls the function ClampAngle
        cameraLook.y = ClampAngle(cameraLook.y, -90, 90);
        
        // Checks if the camera on the y-axis is inverted or not and moves it in the corresponding direction
         if (invertedMouse)
        {
            transform.localRotation = Quaternion.AngleAxis(cameraLook.y, Vector3.right);
        }else
        {
            transform.localRotation = Quaternion.AngleAxis(-cameraLook.y, Vector3.right);
        }
        //The x-axis moves in the corresponding direction
        playerObject.transform.localRotation = Quaternion.AngleAxis(cameraLook.x, playerObject.transform.up);
    }

    /// <summary>
    /// Function that clamps an angle based on a minimum and maximum
    /// </summary>
    /// <param name="angle"> Angle that will be clamped </param>
    /// <param name="min">Minimum angle limit</param>
    /// <param name="max">Maximum angle limit</param>
    /// <returns></returns>
    public static float ClampAngle (float angle, float min, float max)
    {
     if (angle < -360F)
         angle += 360F;
     if (angle > 360F)
         angle -= 360F;
     return Mathf.Clamp (angle, min, max);
    }
}

