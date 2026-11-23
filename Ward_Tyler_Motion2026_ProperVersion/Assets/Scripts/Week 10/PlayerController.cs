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

    // Start is called before the first frame update
    void Start()
    {
        gravity = -2 * apexHeight / (apexTime * apexTime);
        initialJumpVelocity = 2 * apexHeight / apexTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //The input from the player needs to be determined and then passed in the to the MovementUpdate which should
        //manage the actual movement of the character.
        Vector2 playerInput = new Vector2();
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

        //
        if (wasJumpTriggered)
        {
            currentVelocity.y = initialJumpVelocity;
            wasJumpTriggered = false;
        }



        playerRB.linearVelocity = currentVelocity;
    }

    public bool IsWalking()
    {
        return false;
    }
    public bool IsGrounded()
    {
        return true;
    }

    public FacingDirection GetFacingDirection()
    {
        return FacingDirection.left;
    }
}
