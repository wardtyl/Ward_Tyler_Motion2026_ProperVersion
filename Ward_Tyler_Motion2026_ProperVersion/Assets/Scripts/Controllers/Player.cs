using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public Vector3 bombOffset;
    //public Vector2 warpRatio;

    //Week 3 
    public Vector3 currentVelocity = Vector3.right;
    public Vector3 warpPoint = new Vector3(3, 3);
    public float maxSpeed;
    public float accelerationTime;
    public float decelerationTime;
    public float currentAcceleration;
     
    void Update()
    {

        PlayerMovement();


        if (Keyboard.current.bKey.wasPressedThisFrame)
            //isPressed, wasPressedThisFrame, wasReleasedThisFrame
               {
            //Vector2 spawnOffset = new Vector2(0, 1);
            //SpawnBombAtOffset(new Vector2(0, 1));
            //SpawnBombAtOffset(Vector.up);

            //SpawnBombOnRandomCorner(new Vector2(0, 1));

        }
    }

 void Start()
    {
        //basic acceleration
        currentAcceleration = maxSpeed / accelerationTime;
        decelerationTime = maxSpeed / decelerationTime;
        //transform.position = warpPoint * Time.deltaTime;
    }

    public void SpawnBombAtOffset(Vector3 inOffset)
    {
        Instantiate(bombPrefab);
    }

    public void SpawnBombOnRandomCorner(float inDistance)
    {
        Vector2 spawnPos = new Vector2(-50, 50);
        Instantiate(bombPrefab, spawnPos, Quaternion.identity);

        Vector2 spawnPos1 = new Vector2(50, 50);
        Instantiate(bombPrefab, spawnPos1, Quaternion.identity);

        Vector2 spawnPos2 = new Vector2(50, -50);
        Instantiate(bombPrefab, spawnPos2, Quaternion.identity);

        Vector2 spawnPos3 = new Vector2(-50, -50);
        Instantiate(bombPrefab, spawnPos3, Quaternion.identity);
    }

    //public void WarpPlayer(Transform target, float ratio)
    //{

    //}


    //week 3
    //Basic Velocity
    void PlayerMovement()
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
        //ACCELERATION DIRECTION REPRESENTS THE DIRECTION WE ARE ACCELERATING
        //WE NORMALIZE IT 
        //AND THEN SET THE AMOUNT TO ACCELERATE BY:
        currentVelocity += accelerationDirection.normalized * currentAcceleration * Time.deltaTime;




        //player controller (cont)
        if(currentVelocity.magnitude > maxSpeed)
        {
            currentVelocity = currentVelocity.normalized * maxSpeed;
        }

        transform.position = transform.position + currentVelocity * Time.deltaTime;

        //Thought Process Task 1C
        //if (Keyboard.current.leftArrowKey.wasReleasedThisFrame)
        //{
        //    accelerationDirection -= Vector3.left;
        //}

        //if (accelerationDirection = Vector3.zero):
        //{
        //    currentVelocity += accelerationDirection.normalized * currentDeceleraion * Time.deltaTime;
        //}

    }

}
