using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 direction = (GameObject.Find("Player").GetComponent<Transform>().position - GetComponent<Transform>().position).normalized;
        GetComponent<Rigidbody>().velocity = direction * 5f;
    }
}
