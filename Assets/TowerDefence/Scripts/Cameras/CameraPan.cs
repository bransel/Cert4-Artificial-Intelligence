using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour {

    public Camera attachedCamera;
    public float movementThreshold = .25f; // Percentage offset where movement starts (25%)
    public float movementSpeed = 20f;
    public float zoomSensitivity = 100f;
    public Vector3 size = new Vector3(20f, 1f, 20f);

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);

    }

    /// <summary>
    /// Filters incoming position to keep it within bounds
    /// </summary>
    /// <param name="incomingPos">Position that needs filtering</param>
    /// <returns></returns>
    Vector3 GetAdjustedPos(Vector3 incomingPos)

    {
        // Storing in smaller name
        Vector3 pos = transform.position;
        // Getting half size
        Vector3 halfSize = size * 0.5f;

        //x 
        if (incomingPos.x > pos.x + halfSize.x) incomingPos.x = pos.x + halfSize.x;
        if (incomingPos.x < pos.x - halfSize.x) incomingPos.x = pos.x - halfSize.x;

        // y
        //if (incomingPos.y > pos.y + halfSize.y) incomingPos.y = pos.y + halfSize.y;
        //if (incomingPos.y < pos.y - halfSize.y) incomingPos.y = pos.y - halfSize.y;

        // z
        if (incomingPos.z > pos.z + halfSize.z) incomingPos.z = pos.z + halfSize.z;
        if (incomingPos.z < pos.z - halfSize.z) incomingPos.z = pos.z - halfSize.z;

        return incomingPos;
    }




    void Movement()
    {

        //create transform for smaller name
        Transform camTransform = attachedCamera.transform;
        // Get mouse to viewpoint coordinates
        Vector2 mousePoint = attachedCamera.ScreenToViewportPoint(Input.mousePosition);
        // Calculate offset from centre of screen's value
        Vector2 offset = mousePoint - new Vector2(.5f, .5f);
        // Get input only if offset reaches certian threshold
        Vector3 input = Vector3.zero; // The direction to move the camera
        if (offset.magnitude > movementThreshold)
            input = new Vector3(offset.x, 0, offset.y) * movementSpeed;

        // Get scroll from axis and multiply by zoomSensitivitiy
        float inputScroll = Input.GetAxisRaw("Mouse ScrollWheel");
        // zooming , float has to be on the right hand side of a vector 3 for calculations
         Vector3 scroll = camTransform.forward * inputScroll * zoomSensitivity;
        //Vector3 scroll = mousePoint * inputScroll * zoomSensitivity;

        // Apply movement
        Vector3 movement = input + scroll;
        // two vector3s adding
        camTransform.position += movement * Time.deltaTime;

        // Filter position with bounds
        camTransform.position = GetAdjustedPos(camTransform.position);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}
}
