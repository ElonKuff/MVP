using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    CharacterController characterController;
    Animator animator;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float deadzone = 0.3f;

    private Vector3 moveDirection = Vector3.zero;

    void Start(){
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update(){
       
            // We are grounded, so recalculate
            // move direction directly from axes

            if(Mathf.Abs(Input.GetAxis("Horizontal"))>deadzone||Mathf.Abs(Input.GetAxis("Vertical"))>deadzone){
                animator.SetBool("isWalking", true);
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
                moveDirection *= speed;
            } else {
                animator.SetBool("isWalking", false);
            }


            //if (Input.GetButton("Jump"))
            //{
            //   moveDirection.y = jumpSpeed;
            //}

            if(Input.GetButton("Fire1")){
                Debug.Log("Fire");
            }
        

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
