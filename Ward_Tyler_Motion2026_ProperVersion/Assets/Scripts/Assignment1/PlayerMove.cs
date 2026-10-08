using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    public float accelerationTime;
    public float decelerationTime;
    public float currentAcceleration;
    public float currentDeceleration;
    public Vector3 currentVelocity = Vector3.right;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentAcceleration = maxSpeed / accelerationTime;
        currentDeceleration = maxSpeed / decelerationTime;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 accelerationDirection = Vector3.zero;
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            accelerationDirection += Vector3.left;
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            accelerationDirection += Vector3.right;
        }
        if (Keyboard.current.upArrowKey.isPressed)
        {
            accelerationDirection += Vector3.up;
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            accelerationDirection += Vector3.down;
        }
  
        currentVelocity += accelerationDirection.normalized * currentAcceleration * Time.deltaTime;

        //Deceleration
        if (accelerationDirection == Vector3.zero)
        {
            currentVelocity += currentDeceleration * -currentVelocity.normalized * Time.deltaTime;
        }
  
        if (currentVelocity.magnitude > maxSpeed)
        {
            currentVelocity = currentVelocity.normalized * maxSpeed;
        }

        transform.position = transform.position + currentVelocity * Time.deltaTime;

    }

}
