using UnityEngine;
using UnityEngine.InputSystem;

public class SquareSpawner : MonoBehaviour
{
    public Transform aTransform; //x=-4 y=2
    public Transform bTransform; //x=4 y=2
    public Transform cTranform; //x=-4 y=-2
    public Transform dTransform; //x=4 y=-2



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //transform.position = mousePos;

        //if (transform.position = mousePos)
        //{
        //    Debug.DrawLine(aTransform.position, bTransform.position, Color.red);
        //}

        //bool Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //if (mousePos == true)
        //{
        //    Debug.DrawLine(aTransform.position, bTransform.position, Color.magenta);
        //}

    }
}
