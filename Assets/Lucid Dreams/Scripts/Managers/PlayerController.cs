using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    InputManager inputManager;

    public float moveSpeed;
    public float collisionOffset;
    public ContactFilter2D movementFilter;

    private List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    private Rigidbody2D rb;
    private Animator anim;


    private void Start()
    {
        inputManager = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();    
    }

    void FixedUpdate()
    {
        if(inputManager.moveInput != Vector2.zero)
        {
            //Try to move player in input direction, followed by left right and up down input if failed
            bool success = CanMovePlayer(inputManager.moveInput);

            if (!success)
            {
                //Try left / right
                success = CanMovePlayer(new Vector2(inputManager.moveInput.x, 0));

                if (!success)
                {
                    success = CanMovePlayer(new Vector2(0, inputManager.moveInput.y));
                }
            }

            anim.SetBool("isMoving", success);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }

    public bool CanMovePlayer(Vector2 direction)
    {
        //Check for potential collisions
        int count = rb.Cast(direction,  // X and Y values between -1 and 1 that represents the direction from the body to look for collisions
            movementFilter, // The settings that determine where a collision can occur on such as layers to collide with
            castCollisions, //List of collisions to store the found collisions into after the cast has finished
            moveSpeed * Time.fixedDeltaTime + collisionOffset); //The amount to cast equal to the movement plus an offset

        if(count == 0)
        {
            Vector2 moveVector = direction * moveSpeed * Time.fixedDeltaTime;

            //No collisions
            rb.MovePosition(rb.position + moveVector);
            return true;
        }
        else
        {
            return false;
        }
    }

}
