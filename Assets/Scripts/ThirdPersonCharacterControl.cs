using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterControl : MonoBehaviour
{
    public float movementSpeed = 20f;
    public float deadZone = 0.4f;
    private Animator animator;

    public LayerMask groundLayer;
    public float jumpForce = 7;

    public Rigidbody rigidBody;
    private CapsuleCollider collider;
    public bool isGrounded;

    public float distToGround;

    void Start(){
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

	void Update ()
    {
        PlayerMovement();
        PlayerInput();
    }

    void PlayerMovement()
    {

        if(Mathf.Abs(Input.GetAxis("Horizontal"))>deadZone||Mathf.Abs(Input.GetAxis("Vertical"))>deadZone){
            transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * movementSpeed * Time.deltaTime, Space.Self);
            animator.SetFloat("xAxis", Input.GetAxis("Horizontal"));
            animator.SetFloat("yAxis", Input.GetAxis("Vertical"));
        }
        animator.SetBool("isGrounded", isGrounded);
    }

    void PlayerInput(){
        if(Input.GetButtonDown("HighHit")){
            animator.SetTrigger("highHit");
        }
        if(Input.GetButtonDown("Kick")){
            animator.SetTrigger("kickHit");
        }
        if(IsGrounded()&&Input.GetButtonDown("Jump")){
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("hasJumped");
        }
    }

    private bool IsGrounded(){
        isGrounded = Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f);
        
        return isGrounded;
    }
    
}