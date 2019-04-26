using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterControl : MonoBehaviour
{
    public float movementSpeed = 20f;
    public float deadZone = 0.2f;
    private Animator animator;

    void Start(){
        animator = GetComponent<Animator>();
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
        }
        
    }

    void PlayerInput(){
        if(Input.GetButtonDown("HighHit")){
            animator.SetTrigger("highHit");
        }
        if(Input.GetButtonDown("Kick")){
            animator.SetTrigger("kickHit");
        }
    }
}