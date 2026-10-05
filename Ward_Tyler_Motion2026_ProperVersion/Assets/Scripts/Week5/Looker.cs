using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
public class Looker : MonoBehaviour
{
    public List<Transform> targets;
    private int targetIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 firstTarget = targets[targetIndex].position;

        Vector3 vectorToFirstTarget = firstTarget - transform.position;

        //create a static method that accounts for atan2
        float angleToFirstTarget = SolveForAngle.VectorToAngle(vectorToFirstTarget);

        //We have to set the whole vector for euler angles (we can't just set x)
        //want to rotate on z-axis
        transform.eulerAngles = new Vector3(0f, 0f, angleToFirstTarget);

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            targetIndex++;
            if (targetIndex >= targets.Count)
            {
                targetIndex = 0;
            }
        }
    }
}
