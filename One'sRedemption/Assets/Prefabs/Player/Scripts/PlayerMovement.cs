using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public  Rigidbody        myRb;
    public Animator          anim;

    
    public  float            moveSpeed,                            
                             jumpSpeed;

    private Vector3          inputVector;

    public bool              canJump,
                             canMove;

 
    void Update()
    {
        AttackLogic();
        JumpLogic();
        MovementLogic();
    }
    private void FixedUpdate()
    {
        if (inputVector.magnitude > 0 && canMove)
        {
            myRb.MovePosition(myRb.position +
                                    (transform.right * inputVector.x +
                                     transform.forward * inputVector.z) *
                                     moveSpeed * Time.deltaTime);

        }
    }  
    public void AttackLogic()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            anim.SetTrigger("Attack");                    
        }

    }
    public void JumpLogic()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (canJump)
            {
                myRb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);

            }
        }
    }
    public void MovementLogic()
    {
        
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.z = Input.GetAxis("Vertical");
       
        
    }

}
