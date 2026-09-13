using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 originPos = new Vector2(0, 0);

        Vector2 currentPos = new Vector2(3, -2);

        Debug.DrawLine(originPos, currentPos, Color.gray, 15f);
        Debug.Log(currentPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
