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

    public Transform enemy = null;

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
        transform.LookAt(enemy);
    }

    void PlayerMovement()
    {

        if(IsGrounded()&&Input.GetButtonDown("Leap")){
            rigidBody.AddForce(((enemy.transform.position - this.transform.position) + Vector3.up * jumpForce) * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("hasJumped");
        } else if(IsGrounded()&&(Mathf.Abs(Input.GetAxis("Horizontal"))>deadZone||Mathf.Abs(Input.GetAxis("Vertical"))>deadZone)){
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
        
    }

    private bool IsGrounded(){
        isGrounded = Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f);
        
        return isGrounded;
    }

    void OnCollisionEnter(Collision collision){
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        //if (collision.relativeVelocity.magnitude > 2)
            //audioSource.Play();
    }
    
}