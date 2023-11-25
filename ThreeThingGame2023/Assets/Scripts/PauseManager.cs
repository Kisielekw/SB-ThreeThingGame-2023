using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    GameObject[] objects;

    public void SetPause(bool pPause)
    {
        objects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in objects)
        {
            if (obj.tag == "Player")
                obj.GetComponent<Duck>().SetPause(pPause);
            else if (obj.tag == "Enemy")
                obj.GetComponent<Enemy>().SetPause(pPause);
            else if (obj.tag == "Bullet")
                obj.GetComponent<Bullet>().SetPause(pPause);
            else if (obj.tag == "Planet")
                obj.GetComponent<SpawnPowerPlants>().SetPasue(pPause);
        }
    }
}
