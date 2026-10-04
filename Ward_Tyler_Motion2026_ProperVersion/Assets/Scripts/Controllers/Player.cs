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
    public float currentDeceleration;

    //Week 4
    //task 1
    public List<float> circlePoints;
    private int nextCirclePointIndex;
    public float radarRadius;
    //task 2
    public List<GameObject> numberOfPowerups;
    public float radius;
    private int nextPowerupIndex;
    public GameObject powerupPrefab;

    void Update()
    {

        PlayerMovement();
        PlayerRadar();

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
        currentDeceleration = maxSpeed / decelerationTime;
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

        //Deceleration
        if (accelerationDirection == Vector3.zero)
        {
            currentVelocity += currentDeceleration * -currentVelocity.normalized * Time.deltaTime;
        }
        //currentVelocity += currentDeceleration * -currentVelocity.normalized * Time.deltaTime;
        
        //player controller (cont)
        if (currentVelocity.magnitude > maxSpeed)
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

    public void PlayerRadar()
    {
    
        for (int i = 0; i < circlePoints.Count; i++)
        {
            //if statement makes list repeat rather than go on forever
            nextCirclePointIndex = i + 1;

            if(nextCirclePointIndex >= circlePoints.Count)
            {
                nextCirclePointIndex = 0;
            } 

            float currentCirclePoint = circlePoints[i];
            float currentCirclePointInRadians = currentCirclePoint * Mathf.Deg2Rad;

            float nextCirclePoint = circlePoints[nextCirclePointIndex];
            float nextCirclePointInRadians = nextCirclePoint * Mathf.Deg2Rad;

            float startPointX = Mathf.Cos(currentCirclePointInRadians);
            float startPointY = Mathf.Sin(currentCirclePointInRadians);

            Vector3 startPoint = new Vector3(startPointX, startPointY) * radarRadius + transform.position;

            float endPointX = Mathf.Cos(nextCirclePointInRadians);
            float endPointY = Mathf.Sin(nextCirclePointInRadians);

            Vector3 endPoint = new Vector3(endPointX, endPointY) * radarRadius + transform.position;

            Debug.DrawLine(startPoint, endPoint, Color.red);
        }

        //for ()
        //{
        //    Debug.DrawLine(Color.green);
        //}
    }

    //public void SpawnPowerups(float radius, int numberOfPowerups)
    //{


    //    for (int i = 0; i < numberOfPowerups.Count; i++)
    //    {
    //        float currentNumberOfPowerups = numberOfPowerups[i];
    //        float currentNumberOfPowerupsInRadians = currentNumberOfPowerups * Mathf.Deg2Rad;

    //        float nextNumberOfPowerups = numberOfPowerups[nextPowerupIndex];
    //        float nextNumberOfPowerupsInRadians = nextNumberOfPowerups * Mathf.Deg2Rad;

    //        float startPointX = Mathf.Cos(currentNumberOfPowerupsInRadians);
    //        float startPointY = Mathf.Sin(currentNumberOfPowerupsInRadians);

    //        Vector3 startPoint = new Vector3(startPointX, startPointY) * radius + transform.position;

    //        float endPointX = Mathf.Cos(nextNumberOfPowerupsInRadians);
    //        float endPointY = Mathf.Sin(nextNumberOfPowerupsInRadians);

    //        Vector3 endPoint = new Vector3(endPointX, endPointY) * radius + transform.position;

    //        Instantiate(powerupPrefab, startPoint, endPoint, Quaternion.identity);

    //        //Instead of using debug.drawline I think I need to cos and sin to establish a start point and endpoint,
    //        //then use said positions within instantiate (though I don't think I can do this with instantiate syntax)
    //    }
    //}
}
