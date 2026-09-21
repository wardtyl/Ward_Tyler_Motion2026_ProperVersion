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
            //SpawnBombAtOffset(new Vector2(0, 1));
            //SpawnBombAtOffset(Vector.up);

            //SpawnBombOnRandomCorner(new Vector2(0, 1));

        }
    }

 

    public void SpawnBombAtOffset(Vector3 inOffset)
    {
        Instantiate(bombPrefab);
    }

    public void SpawnBombOnRandomCorner(float inDistance)
    {
        Vector2 spawnPos = new Vector2(-50, 50);
        Instantiate(bombPrefab, spawnPos, Quaternion.identity);

        Vector2 spawnPos1 = new Vector2(50, 50);
        Instantiate(bombPrefab, spawnPos1, Quaternion.identity);

        Vector2 spawnPos2 = new Vector2(50, -50);
        Instantiate(bombPrefab, spawnPos2, Quaternion.identity);

        Vector2 spawnPos3 = new Vector2(-50, -50);
        Instantiate(bombPrefab, spawnPos3, Quaternion.identity);
    }

}
