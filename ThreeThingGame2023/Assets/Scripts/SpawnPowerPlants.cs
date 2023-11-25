using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerPlants : MonoBehaviour
{
    public Vector3[] spawnPoints;

    public GameObject powerPlant;

    public int timeInterval;

    private float lastSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTime = 0;

        for(int i = 0; i <= 26; i++)
        {
               Instantiate(powerPlant, spawnPoints[i], Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastSpawnTime >= timeInterval)
        {
            Instantiate(powerPlant, spawnPoints[Random.Range(0, 26)], Quaternion.identity);
            lastSpawnTime = Time.time;
        }
    }
}
