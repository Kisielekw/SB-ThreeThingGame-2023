using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerPlants : MonoBehaviour
{
    public GameObject PauseManager;

    public Vector3[] EnemySpawns;
    public Vector3[] PowerPlantSpawns;

    public GameObject powerPlant;
    public GameObject[] Enemys;

    public int timeIntervalPlants = 5, timeIntervalEnemys = 1;

    private float lastSpawnTimePlant, lastSpawnTimeEnemy;

    private bool pause;

    // Start is called before the first frame update
    void Start()
    {
        pause = false;
        lastSpawnTimePlant = 0;
        lastSpawnTimeEnemy = 0;

        for(int i = 0; i <= 26; i++)
        {
            GameObject newObject = Instantiate(powerPlant, PowerPlantSpawns[Random.Range(0, PowerPlantSpawns.Length)], Quaternion.identity);
            Vector3 upDirection = (newObject.GetComponent<Transform>().position - GameObject.Find("Planet").GetComponent<Transform>().position).normalized;
            Quaternion newRotation = Quaternion.Euler(upDirection);
            newObject.GetComponent<Transform>().rotation = newRotation;
            PauseManager.GetComponent<PauseManager>().AddObject(newObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pause)
            return;

        if(Time.time - lastSpawnTimePlant >= timeIntervalPlants)
        {
            GameObject newObject = Instantiate(powerPlant, PowerPlantSpawns[Random.Range(0, PowerPlantSpawns.Length)], Quaternion.identity);
            Vector3 upDirection = (newObject.GetComponent<Transform>().position - GameObject.Find("Planet").GetComponent<Transform>().position).normalized;
            Quaternion newRotation = Quaternion.Euler(upDirection);
            newObject.GetComponent<Transform>().rotation = newRotation;
            PauseManager.GetComponent<PauseManager>().AddObject(newObject);
            lastSpawnTimePlant = Time.time;
        }

        if(Time.time - lastSpawnTimeEnemy >= timeIntervalEnemys)
        {
            GameObject newObject = Instantiate(Enemys[Random.Range(0, Enemys.Length)], EnemySpawns[Random.Range(0, EnemySpawns.Length)], Quaternion.identity);
            Vector3 upDirection = (newObject.GetComponent<Transform>().position - GameObject.Find("Planet").GetComponent<Transform>().position).normalized;
            Quaternion newRotation = Quaternion.Euler(upDirection);
            newObject.GetComponent<Transform>().rotation = newRotation;
            PauseManager.GetComponent<PauseManager>().AddObject(newObject);
            lastSpawnTimeEnemy = Time.time;
        }
    }

    public void SetPasue(bool pPause)
    {
        pause = pPause;
    }
}
