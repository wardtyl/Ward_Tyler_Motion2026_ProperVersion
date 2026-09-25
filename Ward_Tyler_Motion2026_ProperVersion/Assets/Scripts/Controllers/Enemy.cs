using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public float maxSpeed;
    public float accelerationTime;
    public float decelerationTime;
    public float currentAcceleration;
    public float currentDeceleration;
    public Vector3 currentVelocity = Vector3.right;

    void Start()
    {
        currentAcceleration = maxSpeed / accelerationTime;
        currentDeceleration = maxSpeed / decelerationTime;
    }

    void Update()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        Vector3 accelerationDirection = Vector3.zero;

        if (screenPos.x < 0)
        {
            accelerationDirection += Vector3.right;
        }
        if (screenPos.x > Screen.width)
        {
            accelerationDirection += Vector3.left;
        }

        currentVelocity += accelerationDirection.normalized * currentAcceleration * Time.deltaTime;

        //Deceleration
        //if (accelerationDirection == Vector3.zero)
        //{
        //    currentVelocity += currentDeceleration * -currentVelocity.normalized * Time.deltaTime;
        //}
    }

}
