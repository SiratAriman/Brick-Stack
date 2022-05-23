using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject Spawner;
    public bool StopSpawning = false;
    public float SpawnTime;
    public float SpawnDelay;

    void Start()
    {
        InvokeRepeating("SpawnObject", SpawnTime, SpawnDelay);
        
    }

    public void SpawnObject()
    {
        Instantiate(Spawner, transform.position, transform.rotation);
        if (StopSpawning)
        {
            CancelInvoke("SpawnObject");

        }
    }
}
