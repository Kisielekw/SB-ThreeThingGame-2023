using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool pause;
    private float lastShootTime;
    private float shootInterval;

    private State state;

    private Vector3 gravity;

    public GameObject Bullet;

    enum State
    {
        Idle,
        Shooting
    }

    // Start is called before the first frame update
    void Start()
    {
        lastShootTime = 0;
        shootInterval = 5;
        state = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Idle:
                Idle();
                break;
            case State.Shooting:
                Shooting();
                break;
        }
    }

    public void SetPause(bool pPause)
    {
        pause = pPause;
    }

    void Idle()
    {
        if (pause)
            return;

        float distanceToPlayer = Vector3.Distance(GameObject.Find("Player").GetComponent<Transform>().position, GetComponent<Transform>().position);
        if (distanceToPlayer <= 20)
            state = State.Shooting;
    }

    void Shooting()
    {
        if (pause)
            return;

        float distanceToPlayer = Vector3.Distance(GameObject.Find("Player").GetComponent<Transform>().position, GetComponent<Transform>().position);
        if(distanceToPlayer >= 20)
        {
            state = State.Idle;
            return;
        }

        if(Time.time - lastShootTime >= shootInterval)
        {
            GameObject newBullet = Instantiate(Bullet, GetComponent<Transform>().position, Quaternion.identity);
            Vector3 upDirection = (newBullet.GetComponent<Transform>().position - GameObject.Find("Planet").GetComponent<Transform>().position).normalized;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, upDirection);
            newBullet.GetComponent<Transform>().rotation = rotation;
            Destroy(newBullet, 5);
            lastShootTime = Time.time;
        }
    }
}
