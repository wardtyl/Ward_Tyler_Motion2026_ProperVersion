using UnityEngine;

public class EnemyPivot : MonoBehaviour
{
    public Transform targetTransform;
    public float rotationSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToTarget = targetTransform.position - transform.position;

        //Should we turn left or right:
        bool shouldWeTurnRight = false;
        float dotProductOfRight = AngleSolution.VectorDot(directionToTarget, transform.right);
        shouldWeTurnRight = dotProductOfRight > 0f;

        if(dotProductOfRight > 1 || dotProductOfRight < -1)
        {
            //transform.eulerAngles = Vector3.zero * rotationSpeed * Time.deltaTime;
        }
        else
        {
            if (shouldWeTurnRight)
            {
                transform.eulerAngles -= Vector3.forward * rotationSpeed * Time.deltaTime;
            }
            else
            {
                transform.eulerAngles += Vector3.forward * rotationSpeed * Time.deltaTime;
            }
        }
    }
}
