using System.Net.NetworkInformation;
using UnityEngine;

public class Wormhole : MonoBehaviour
{
    public Transform player;
    public Transform targetPortal;
    public float activationRange = 0.5f;
    public Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) < activationRange)
        {
            player.position = targetPortal.position + offset;
        }
    }

}
