using UnityEngine;

public class SolveForAngle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Why acos asin does not work
        //float firstAngle = 45f;
        //float secondAngle = 315f;

        //float firstVectorX = Mathf.Cos(45f * Mathf.Deg2Rad);
        //float secondVectorX = Mathf.Cos(315f * Mathf.Deg2Rad);

        //Debug.Log(firstVectorX);
        //Debug.Log(secondVectorX);

        //float firstAngleAgain = Mathf.Acos(firstVectorX) * Mathf.Rad2Deg;
        //float secondAngleAgain = Mathf.Acos(secondVectorX) * Mathf.Rad2Deg;

        //Debug.Log(firstAngleAgain);
        //Debug.Log(secondAngleAgain);

        //atan faces the same issue regarding negatives equaling same result as positive

        //float x = 0.7f;
        //float y = -0.7f;

        //float angle = Mathf.Atan(y / x);

        //float x2 = -0.7f;
        //float y2 = 0.7f;
        //float angle2 = Mathf.Atan(y2 / x2);

        //Mathf.Atan2(0.7f, -0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //convert from vector to angle based around the x-axis
    //static allows to use method in other scripts
    public static float VectorToAngle(Vector3 inVector)
    {
        float angle = Mathf.Atan2(inVector.y, inVector.x) * Mathf.Rad2Deg;

        //-90f accounts for unity rotation
        return angle - 90f;
    }

    public static float VectorDot(Vector3 a, Vector3 b)
    {
        float dotProduct = a.x * b.x + a.y * b.y;
        return dotProduct;
    }
}
