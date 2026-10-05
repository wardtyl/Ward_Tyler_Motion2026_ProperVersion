using System.Net.NetworkInformation;
using UnityEngine;

public class Wormhole : MonoBehaviour
{
    bool touchingPortal = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Portal();
    }

    void Portal()
    {
        //need if statement saying if player touching portal is true, touching portal == true

        //Should I use points on a circle to dictate the entry point of portal?

        if (touchingPortal == true)
        {
           Vector2 originPos = new Vector2(10, -5);
           Vector2 currentPos = new Vector2(-10, 5);

        Debug.DrawLine(originPos, currentPos, Color.magenta, 2f);
        }

        //need two seperate scripts (one for each portal) or can I just alternate origin and current depending on 
        //which portal is entered
    }
}
