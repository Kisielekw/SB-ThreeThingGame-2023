using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerPlants : MonoBehaviour
{
    public Vector3[] spawnPoints;

    public GameObject powerPlant;

    public int timeInterval = 5;

    private float lastSpawnTime;

    private bool pause;

    // Start is called before the first frame update
    void Start()
    {
        pause = false;
        lastSpawnTime = 0;

        for(int i = 0; i <= 26; i++)
        {
            GameObject newObject = Instantiate(powerPlant, spawnPoints[Random.Range(0, 26)], Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pause)
            return;

        if(Time.time - lastSpawnTime >= timeInterval)
        {
            GameObject newObject = Instantiate(powerPlant, spawnPoints[Random.Range(0, 26)], Quaternion.identity);
            Vector3 upDirection = (newObject.GetComponent<Transform>().position - GameObject.Find("Planet").GetComponent<Transform>().position).normalized;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, upDirection);
            newObject.GetComponent<Transform>().rotation = rotation;
            lastSpawnTime = Time.time;
        }
    }

    public void SetPasue(bool pPause)
    {
        pause = pPause;
    }
}
