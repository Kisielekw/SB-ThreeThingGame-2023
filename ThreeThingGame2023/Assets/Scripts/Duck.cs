using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Duck : MonoBehaviour
{
    Vector3 gravity;
    GameObject Planet;

    Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();

        gravity = new Vector3(0, 0, 0);
        Planet = GameObject.Find("Planet");
    }

    // Update is called once per frame
    void Update()
    {
        gravity = (Planet.transform.position - transform.position).normalized;

        if(Input.GetKey(KeyCode.W))
            transform.Translate(new Vector3(0, 0, 10) * Time.deltaTime);
        if(Input.GetKey(KeyCode.S))
            transform.Translate(new Vector3(0, 0, -10) * Time.deltaTime);
        if(Input.GetKey(KeyCode.A))
            transform.Translate(new Vector3(-10, 0, 0) * Time.deltaTime);
        if(Input.GetKey(KeyCode.D))
            transform.Translate(new Vector3(10, 0, 0) * Time.deltaTime);
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(gravity * 9.81f);
    }
}
