using UnityEngine;
using UnityEngine.InputSystem;

public class VectorAddition : MonoBehaviour
{
    public Transform rTransform;
    public Transform bTransform;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.rKey.isPressed)
        {
            Debug.DrawLine(Vector2.zero, rTransform.position, Color.red);
        }
        if (Keyboard.current.bKey.isPressed)
        {
            Debug.DrawLine(Vector2.zero, bTransform.position, Color.blue);
        }

        Vector2 rPlusB = rTransform.position + bTransform.position;
        bool wasRAndBPressed = Keyboard.current.rKey.isPressed && Keyboard.current.bKey.isPressed;
        if (wasRAndBPressed == true)
        {
            Debug.DrawLine(Vector2.zero, rPlusB, Color.magenta);
        }

        //calculating magnitude
        float sizeOfRPlusB = Mathf.Sqrt(rPlusB.x * rPlusB.x + rPlusB.y * rPlusB.y);
        Debug.Log(sizeOfRPlusB);
        Debug.DrawLine(Vector2.zero, rPlusB, Color.magenta);

        //direction to target
        Vector2 fromRToB = bTransform.position - rTransform.position;
    }
}
