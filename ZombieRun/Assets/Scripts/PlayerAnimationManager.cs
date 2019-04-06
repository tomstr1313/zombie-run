using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private Animator animator;
    private InputState inputState;

   
    void Awake()
    {
        animator = GetComponent<Animator>();
        inputState = GetComponent<InputState>();
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        //check if player state changes and then change animation
        var running = true;
        var jumping = false;
        var idle = false;
        if (inputState.absVelX > 0 && inputState.absVelY < inputState.standingThreshold)
        {


            running = false;
            jumping = false;
            idle = true;
            animator.SetBool("Running", running);
            animator.SetBool("Jumping", jumping);
            animator.SetBool("Idle", idle);

        }

        else if (Input.GetKeyDown(KeyCode.Space))
        {
            running = false;
            jumping = true;
            idle = false;

            animator.SetBool("Running", running);
            animator.SetBool("Jumping", jumping);
            animator.SetBool("Idle", idle);

        }
        else
        {
            running = true;
            jumping = false;
            idle = false;
            animator.SetBool("Running", running);
            animator.SetBool("Jumping", jumping);
            animator.SetBool("Idle", idle);
        }

    }
}
