using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCharacterJump : MonoBehaviour {
    public float jumpSpeed = 10;
    Vector3 moveDir;
    public float gravity = 1f;
    private CharacterController _characterController;
    public Vector3 moveDirection,parentDirection;

    float y =1;
    // Use this for initialization
    void Start () {
       _characterController = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetButton("Jump"))
        {

            transform.Translate(Vector3.up * jumpSpeed* Time.deltaTime);

        }
        /* if (_characterController.isGrounded)
         {
             moveDirection = new Vector3(0, 1, 0);
             if (Input.GetButton("Jump"))

             {


                moveDirection.y = jumpSpeed;

                 //_characterController.Move(transform.localPosition * Time.deltaTime);

             }
         }

         y -= gravity * Time.deltaTime; */


    }
}
