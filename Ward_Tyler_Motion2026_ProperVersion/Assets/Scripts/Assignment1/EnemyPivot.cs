using UnityEngine;

public class EnemyPivot : MonoBehaviour
{
    public Transform targetTransform;
    public float rotationSpeed;
    public float positiveRange;
    public float negativeRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Determines player position
        Vector3 directionToTarget = targetTransform.position - transform.position;

        //Ensures that if player goes behind enemy they will not rotate
        //If the player is above enemy, logic is not being applied
        float verticalDotProduct = AngleSolution.VectorDot(directionToTarget, Vector3.down);
        if (verticalDotProduct > 0)
        {
            //Keeps enemy from rotating beyond assigned Dot Product
            //direction of sightline
            float dotProductEnemyRange = AngleSolution.VectorDot(directionToTarget, Vector3.left);

            //bounds of sightline 
            if (dotProductEnemyRange > positiveRange || dotProductEnemyRange < negativeRange)
            {
                //if out of range stop moving  
            }
            else
            {
                //Direction to turn
                bool shouldWeTurnRight = false;

                //When in the dot product of vector3.left (sightline), ensures it is directly lined up with the player
                float dotProductEnemyRange2 = AngleSolution.VectorDot(directionToTarget, transform.right);
                shouldWeTurnRight = dotProductEnemyRange2 > 0f;

                //Whether we should turn left or right
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
}