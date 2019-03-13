using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{//to orbit around a target-> 
    // public Transform target;



    // Distance the camera is from world zero
    public float distance = 10f;
    // X and Y rotation speed
    public float xSpeed = 120f, ySpeed = 120f;
    // X and Y rotation limits
    public float yMin = 15f, yMax = 80f;
    // Stores current x and y rotation
    private float x, y;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void LateUpdate()
    {

        // If the right mouse button is pressed
        if (Input.GetMouseButton(1))
        {
            // Hide the cursor
            Cursor.visible = false;
            // Get input X and Y offsets
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            // Offset rotation with mouse X and Y
            x += mouseX * xSpeed * Time.deltaTime;
            y -= mouseY * ySpeed * Time.deltaTime;
            // Clamp the Y between min and max limits
            y = Mathf.Clamp(y, yMin, yMax);
        }
        else
        {
            //Show cursor
            Cursor.visible = true;
        }

        //Update transform
        transform.rotation = Quaternion.Euler(y, x, 0);
        transform.position = -transform.forward * distance;
        // to transform around a target:
// transform.position = target.position - transform.forward * distance
    }



}
