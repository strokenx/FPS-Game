using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that controls the movement of the player
/// </summary>
public class FPSMove : MonoBehaviour
{
    //Speed of movement
    public float speed = 2.5f;

	// Update is called once per frame
	void Update () 
    {
        // Player movement is controlled according to the ASDW keyboard layout and based on a speed in the deltaTime
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }    
    }
}
