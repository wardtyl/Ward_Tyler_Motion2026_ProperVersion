using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Moon : MonoBehaviour
{
    public GameObject orbitalSystemPrefab;
    public Transform planetTransform;
    public List<float> angles;
    private int currentAngleIndex = 0;
    public float radius;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion();
    }
    public void OrbitalMotion()
    {
        float currentAngle = angles[currentAngleIndex];
        float currentAngleInRadians = currentAngle * Mathf.Deg2Rad;

        //Will start at centre of screen?
        Vector3 startPoint = Vector3.zero;
        float endPointX = Mathf.Cos(currentAngleInRadians);
        float endPointY = Mathf.Sin(currentAngleInRadians);

        Vector3 endPoint = new Vector3(endPointX, endPointY) * radius * speed;

        //How to rotate using start and end points?
        
    }
}
