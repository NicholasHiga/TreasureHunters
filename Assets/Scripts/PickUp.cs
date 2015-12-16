using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PickUp : MonoBehaviour
{
    float currentHealth = 0;
    float maxHealth = 100;
    float calculatedHealth;
    public GameObject HealthBar;
    public GameObject HealthBarBig;
    public GameObject Tele1;
    public GameObject Tele2;
    int healthPot;
    int RhealthPot;
    bool Raged;
    bool hyper;
    float RagedTimer;
    float hyperTimer;
    float teleTimer;
    Vector3 orgLocalScale;
    bool allowedTele;


    void Start()
    {
		Debug.Log(gameObject.name);
		currentHealth = 1;
        calculatedHealth = currentHealth / maxHealth;
        setHealthBar(calculatedHealth);
        healthPot = 0;
        Raged = false;
        hyper = false;
        RagedTimer = 0;
        teleTimer = 0;
        hyperTimer = 0;
        orgLocalScale = transform.localScale;
        allowedTele = true;
    }

    void FixedUpdate()
    {
        RagedTimer -= Time.deltaTime;
        hyperTimer -= Time.deltaTime;
        teleTimer -= Time.deltaTime;
        ItemUsage();
        if (healthPot >= 3)
        {
            healthPot = 3;
        }
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
            calculatedHealth = currentHealth / maxHealth;
            setHealthBar(calculatedHealth);
        }
        State();
      

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "RawChicken")
        {
            healthPot++;
        }
        else if (col.gameObject.tag == "RedPowerUp" && !hyper)
        {

            if (!Raged)
            {
                Enraged();
            }
            Raged = true;
        }
        else if (col.gameObject.tag == "PurplePowerUp" && !Raged)
        {
            if (!hyper)
            {
                Encouraged();
            }
            hyper = true;
        }
        else if (col.gameObject.tag == "Tele1"&&allowedTele)
        {
            transform.position = Tele2.transform.position;
            allowedTele = false;
            Teled();
        }
        else if (col.gameObject.tag == "Tele2"&&allowedTele)
        {
            transform.position = Tele1.transform.position;
            allowedTele = false;
            Teled();
        }
    }
    public void setHealthBar(float myHealth)
    {
        HealthBar.transform.localScale = new Vector3(myHealth, HealthBar.transform.localScale.y, HealthBar.transform.localScale.z);
        HealthBarBig.transform.localScale = new Vector3(myHealth, HealthBarBig.transform.localScale.y, HealthBarBig.transform.localScale.z);
    }

    void ItemUsage()
    {

        if (healthPot > 0 && Input.GetKey(KeyCode.Alpha6) && currentHealth < maxHealth)
        {

            currentHealth += 50;
            calculatedHealth = currentHealth / maxHealth;
            setHealthBar(calculatedHealth);

        }

    }
    void Enraged()
    {
        RagedTimer = 5;
        if (Raged == false)
        {
            transform.localScale += new Vector3(.5f, .5f, 0);
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }
    void Encouraged()
    {
        hyperTimer = 10;
        if (hyper == false)
        {
            gameObject.GetComponent<Movement>().horizontalSpeed = 9;
            gameObject.GetComponent<Movement>().verticalSpeed = 6;
            gameObject.GetComponent<Renderer>().material.color = Color.magenta;
        }
    }
    void Teled()
    {
        teleTimer = 2;
    }
    void State()
    {
        if (Raged)
        {

            Debug.Log(RagedTimer.ToString());
            if (RagedTimer <= 0)
            {
                Raged = false;
                transform.localScale = orgLocalScale;
            }
        }
        if (!Raged&&!hyper)
        {
            
            gameObject.GetComponent<Renderer>().material.color = Color.white;

        }
        if (hyper)
        {
            Debug.Log(hyperTimer.ToString());
            if (hyperTimer <= 0)
            {
                hyper = false;
            }
        }
        if (!hyper&&!Raged)
        {
            /*gameObject.GetComponent<Movement>().horizontalSpeed = 3;
            gameObject.GetComponent<Movement>().verticalSpeed = 2;
            gameObject.GetComponent<Renderer>().material.color = Color.white;*/
        }
        if (!allowedTele)
        {
            
            Debug.Log(teleTimer.ToString());
            if (teleTimer <= 0)
            {
                allowedTele = true; 
            }

        }
    }
}

