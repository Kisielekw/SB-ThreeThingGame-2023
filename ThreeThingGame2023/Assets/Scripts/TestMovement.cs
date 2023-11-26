using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public GameObject Sphere;

    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction += new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        transform.position = Sphere.transform.position + 25.5f * new Vector3(Mathf.Cos(Mathf.Deg2Rad * -direction.x * 0.1f), Mathf.Sin(Mathf.Deg2Rad * -direction.x * 0.1f) + Mathf.Cos(Mathf.Deg2Rad * direction.y * 0.1f), Mathf.Sin(Mathf.Deg2Rad * direction.y * 0.1f));
        Quaternion newRotation = Quaternion.Euler(0, 0, -direction.x * 0.1f);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * int.MaxValue);
    }
}
