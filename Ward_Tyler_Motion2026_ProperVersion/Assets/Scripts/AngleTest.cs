using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class AngleTest : MonoBehaviour
{
    public List<float> angles;
    private int currentAngleIndex = 0;

    public float circleRadius;
    public Vector3 circleOffset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //float fortyFiveDegree = 45f;

        //float ffDInRadians = fortyFiveDegree * Mathf.Deg2Rad;


        //float twoPiRadians = 2 * Mathf.PI;
        //float tprInDegrees = twoPiRadians * Mathf.Rad2Deg;

        //float currentAngle = 90f;
        //Mathf.Cos(currentAngle * Mathf.Deg2Rad);
        //Mathf.Sin(currentAngle * Mathf.Deg2Rad);


    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            currentAngleIndex++;

            if (currentAngleIndex >= angles.Count)
            {
                currentAngleIndex = 0;
            }
        }


        float currentAngle = angles[currentAngleIndex];
        float currentAngleInRadians = currentAngle * Mathf.Deg2Rad;

        Vector3 startPoint = Vector3.zero;
        float endPointX = Mathf.Cos(currentAngleInRadians);
        float endPointY = Mathf.Sin(currentAngleInRadians);
        Vector3 endPoint = new Vector3(endPointX, endPointY);

        Debug.DrawLine(startPoint, endPoint, Color.wheat);

    }
}

