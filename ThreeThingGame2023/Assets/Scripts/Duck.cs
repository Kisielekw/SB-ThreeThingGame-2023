using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Duck : MonoBehaviour
{
    private Vector3 gravity;

    private GameObject Planet;

    private int health, radiation, radiationNextLevel;
    private bool pause;

    private int damage;
    private float speed;

    public GameObject PauseManager;

    public GameObject LevelScreen, DeathScreen;

    public Image healthBar, radiationBar;

    public AudioClip[] Music;
    public AudioClip LevelUp, Death;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().clip = Music[0];

        PauseManager.GetComponent<PauseManager>().AddObject(gameObject);

        pause = false;

        health = 100;
        radiation = 0;
        radiationNextLevel = 25;

        gravity = new Vector3(0, 0, 0);
        Planet = GameObject.Find("Planet");
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().clip = Music[1];
            GetComponent<AudioSource>().Play();
        }

        if (pause)
            return;

        gravity = (Planet.transform.position - transform.position).normalized;
    }

    void FixedUpdate()
    {
        if (pause)
            return;

        if (Input.GetKey(KeyCode.W))
            transform.Translate(new Vector3(0, 0, 10) * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(new Vector3(0, 0, -10) * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(new Vector3(-10, 0, 0) * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(new Vector3(10, 0, 0) * Time.deltaTime);

        GetComponent<Rigidbody>().AddForce(gravity * 9.81f);
    }

    public void Damage(int pDamage)
    {
        health -= pDamage;

        healthBar.fillAmount = health / 100f;

        if(health <= 0)
        {
            DeathScreen.SetActive(true);
            GetComponent<AudioSource>().clip = Death;
            GetComponent<AudioSource>().Play();
        }
    }

    public void AbsorbRadiation(int pRadiation)
    {
        radiation += pRadiation;

        radiationBar.fillAmount = radiation / radiationNextLevel;

        if(radiation == radiationNextLevel)
        {
            ResetRadiation();
        }
    }

    public void ResetRadiation()
    {
        GetComponent<AudioSource>().clip = LevelUp;
        GetComponent<AudioSource>().Play();

        LevelScreen.SetActive(true);
        PauseManager.GetComponent<PauseManager>().SetPause(true);

        radiation = 0;
        radiationBar.fillAmount = 0;
        radiationNextLevel += 25;
    }

    public void SetPause(bool pPause)
    {
        pause = pPause;
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.tag == "Radiation")
        {
            Destroy(other.gameObject);
            AbsorbRadiation(1);
        }
        if(other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Damage(5);
        }
    }

    public void IncreaseDamage(int pDamage)
    {
        damage += pDamage;
    }

    public void IncreaseSpeed(float pSpeed)
    {
        speed += pSpeed;
    }

    public void IncreaseHealth(int pHealth)
    {
        health += pHealth;
    }
}
