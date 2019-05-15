using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayer : MonoBehaviour
{

    public float runSpeed = 8f;
    public float walkSpeed = 6f;
    public float gravity = -10f;
    public float crouchSpeed = 4f;
    public float jumpHeight = 15f;
    public float groundRayDistance = 1.1f;
    public float sprintSpeed = 10f;
    public LayerMask groundLayer;


    private CharacterController controller;
    private Vector3 motion;

    private bool isJumping = false;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        bool inputJump = Input.GetButtonDown("Jump");

        Move(inputH, inputV);



        if (IsGrounded() && inputJump)
        {
            // make character jump
            Jump(jumpHeight);
        }

        //If not grounded anymore and is  not jumping
        if (IsGrounded() && !isJumping)
        {

            motion.y = 0f;
        }

        // If is grounded and is jumping

        if (!IsGrounded() && isJumping)
        {
            isJumping = false;

        }

        motion.y += gravity * Time.deltaTime;

        // Applies motion to Character Controller
        controller.Move(motion * Time.deltaTime);


    }

    //Test if the player is grounded
    public bool IsGrounded()

    {
        Ray groundRay = new Ray(transform.position, -transform.up);
        // performing raycast
        if (Physics.Raycast(groundRay, groundRayDistance, groundLayer))
        {
            // return true if hit

            return true; // exits the function once it hits a return
        }
        // return false if not hit
        return false;

        //return Physics.Raycast(transform.position, -transform.up, groundRayDistance));
    }

    public void Move(float inputH, float inputV)
    {
        Vector3 direction = new Vector3(inputH, 0f, inputV);

        // Convert local direction from world space
        direction = transform.TransformDirection(direction);
        if (Input.GetButton("Sprint"))
        {
            motion.x = direction.x * sprintSpeed;
            motion.z = direction.z * sprintSpeed;
        }

        else
        {
            motion.x = direction.x * walkSpeed;
            motion.z = direction.z * walkSpeed;
        }

        

        Debug.Log(motion.x);


    }
    public void Jump(float height)
    {
        motion.y = height;
        isJumping = true;
    }
}
   
