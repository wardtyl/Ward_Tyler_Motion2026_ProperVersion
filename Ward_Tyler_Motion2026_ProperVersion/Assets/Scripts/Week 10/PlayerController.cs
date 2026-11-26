using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public enum FacingDirection
    {
        left, right
    }

    public float apexHeight;
    public float apexTime;
    public Rigidbody2D playerRB;
    float gravity;
    float initialJumpVelocity;
    private bool wasJumpTriggered = false;
    public float maxSpeed;
    public float accelerationTime;
    public float acceleration;
    public float decelerationTime;
    public float deceleration;

    public FacingDirection facingDirection;

    // Start is called before the first frame update
    void Start()
    {
        gravity = -2 * apexHeight / (apexTime * apexTime);
        initialJumpVelocity = 2 * apexHeight / apexTime;

        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //The input from the player needs to be determined and then passed in the to the MovementUpdate which should
        //manage the actual movement of the character.
        Vector2 playerInput = new Vector2();

        if (Keyboard.current.rightArrowKey.isPressed)
        {
            playerInput.x += 1f;
            facingDirection = FacingDirection.right;
        }
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            playerInput.x -= 1f;
            facingDirection = FacingDirection.left;
        }

        MovementUpdate(playerInput);
    }


    void Update()
    {
        //If the player provides input for a jump, give them the initial jump velocity
        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            wasJumpTriggered = true;
        }
    }

    private void MovementUpdate(Vector2 playerInput)
    {
        //need walking, rb stuff for jumping

        Vector2 currentVelocity = playerRB.linearVelocity;

        //Apply the gravity that we calculate over time
        currentVelocity.y += gravity * Time.fixedDeltaTime;

        if (wasJumpTriggered)
        {
            currentVelocity.y = initialJumpVelocity;
            wasJumpTriggered = false;
        }

        playerRB.linearVelocity = currentVelocity;

        //walking
        Vector2 newVelocity = playerRB.linearVelocity;
        if (playerInput.x != 0)
        {
            //accelerate
            newVelocity += playerInput * acceleration * Time.deltaTime;
        }
        else
        {
            newVelocity.x = Mathf.MoveTowards(newVelocity.x, 0, deceleration * Time.deltaTime);
        }
        playerRB.linearVelocity = newVelocity;
    }


    public bool IsWalking()
    {
        if (Mathf.Abs(playerRB.linearVelocity.x) > 0.01f)
        {
            return true;
        }
        
        
           return false;
        
    }
        
    public bool IsGrounded()
    {
        //raycast physics 2d player, down, layermask
        //need public layermask
        return true;
    }

    public FacingDirection GetFacingDirection()
    {
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            return FacingDirection.left;
        }

        if (Keyboard.current.rightArrowKey.isPressed)
        {
            return FacingDirection.right;
        }


        return facingDirection;
        
    }
}
