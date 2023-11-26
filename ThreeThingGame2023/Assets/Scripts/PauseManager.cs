using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    List<GameObject> objects;

    private void Start()
    {
        objects = new List<GameObject>();
    }

    public void AddObject(GameObject obj)
    {
        objects.Add(obj);
    }

    public void RemoveObject(GameObject obj)
    {
           objects.Remove(obj);
    }

    public void SetPause(bool pPause)
    {
        foreach (GameObject obj in objects)
        {
            if (obj.tag == "Player")
                obj.GetComponent<Duck>().SetPause(pPause);
            else if (obj.tag == "Enemy")
                obj.GetComponent<Enemy>().SetPause(pPause);
            else if (obj.tag == "Planet")
                obj.GetComponent<SpawnPowerPlants>().SetPasue(pPause);
        }
    }
}
