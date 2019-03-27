using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour {

    public Camera attachedCamera;
    [Header("Orbit")]
    public Vector3 offset = new Vector3(0, 5f, 0); // Vector offset from original position
    public float xSpeed = 120.0f, ySpeed = 120.0f;
    public float yMinLimit = -20f, yMaxLimit = 80f;
    public float distanceMin = .5f, distanceMax = 15f;

    [Header("Collision")]
    public bool cameraCollision = true; // Is camera collision enabled?
    public bool ignoreTriggers = true;
    public float castRadius = .3f; // Radius of the camera collision cast
    public float castDistance = 1000f;
    public LayerMask hitlayers; // Layers ignored by collision

    private float originalDistance;
    private float distance; // Current distance to camera
    private float x, y; // Y degress of rotation 

    // Use this for initialization
    void Start()
    {
        // Set ray distance to current distance magnitude of Camera
        originalDistance = Vector3.Distance(transform.position, attachedCamera.transform.position);
        // Get current camera rotation
        Vector3 angles = transform.eulerAngles;

        // set X and Y degrees to current camera rotation
        x = angles.y;
        y = angles.x;


    }

    // Update is called once per frame
    void Update()
    {

        // If Right-Click is down
        if (Input.GetMouseButton(1))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            // Rotate the camera based on mouse X and Mouse Y inputs
            x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
            y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;

            // Clamp the angle using a custom 'ClampAngle' function defined in this script
            y = Mathf.Clamp(y, yMinLimit, yMaxLimit);

            // Rotate the transform using euler angles (y for x rotation and x for Y rotation)
            transform.rotation = Quaternion.Euler(y, x, 0);
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }





    }
    void LateUpdate()
    {
        // set distance to original distance
        distance = originalDistance;

        // Is camera collision enabled?
        if (cameraCollision)
        {
            // Create a ray starting from target's position and pointing backwrads from camera
            Ray camRay = new Ray(transform.position, -transform.forward);
            RaycastHit hit;

            // Shoot a sphere in defined ray direction
            if (Physics.SphereCast(camRay, castRadius, out hit, castDistance, hitlayers, ignoreTriggers ? QueryTriggerInteraction.Ignore : QueryTriggerInteraction.Collide))
            {
                // Set current camera distance to hit objects distance
                distance = hit.distance;

            }
        }
        attachedCamera.transform.position = transform.position - transform.forward * distance;
    }
}
