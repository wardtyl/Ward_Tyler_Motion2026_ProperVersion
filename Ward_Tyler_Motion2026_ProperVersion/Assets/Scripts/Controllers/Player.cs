using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public Vector3 bombOffset;

    void Update()
    {
        if (Keyboard.current.bKey.wasPressedThisFrame)
            //isPressed, wasPressedThisFrame, wasReleasedThisFrame
               {
            //Vector2 spawnOffset = new Vector2(0, 1);
            SpawnBombAtOffset(new Vector2(0, 1));
            //SpawnBombAtOffset(Vector.up);
                }
        //SpawnBombAtOffset(Keyboard.current.bKey.wasPressedThisFrame);
    }

    //public void SpawnBombAtOffset(Vector3 inOffset)
    //{
    //    if(Keyboard.current.bKey.wasPressedThisFrame)
    //    {
    //        Instantiate
    //    }
    //

    public void SpawnBombAtOffset(Vector3 inOffset)
    {
        Instantiate(bombPrefab);
    }

}
