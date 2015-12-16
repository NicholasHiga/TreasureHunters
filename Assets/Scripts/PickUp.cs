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
    public GameObject Player;
    int healthPot;
    int RhealthPot;
    bool Raged;
    bool hyper;
    bool trapped;
    float RagedTimer;
    float hyperTimer;
    float teleTimer;
    float TrapTimer;
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
        trapped = false;
        RagedTimer = 0;
        teleTimer = 0;
        hyperTimer = 0;
        TrapTimer = 0;
        orgLocalScale = transform.localScale;
        allowedTele = true;
    }

    void FixedUpdate()
    {
        RagedTimer -= Time.deltaTime;
        hyperTimer -= Time.deltaTime;
        teleTimer -= Time.deltaTime;
        TrapTimer -= Time.deltaTime;
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
        else if (col.gameObject.tag == "T")
        {
            trapped = true;
            Trapped();
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
            Player.transform.localScale = new Vector3(1.5f, 1.5f, 0);
            Player.GetComponent<Renderer>().material.color = Color.red;
        }
    }
    void Encouraged()
    {
        hyperTimer = 10;
        if (hyper == false)
        {
            Player.GetComponent<Movement>().horizontalSpeed = 5;
            Player.GetComponent<Movement>().verticalSpeed = 4;
            Player.GetComponent<Renderer>().material.color = Color.magenta;
        }
    }
    void Teled()
    {
        teleTimer = 2;
    }

    void Trapped()
    {
        TrapTimer = 2.5f;
        if (trapped)
        {
            Player.GetComponent<Movement>().enabled = false;
        }
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
            
            Player.GetComponent<Renderer>().material.color = Color.white;

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
<<<<<<< HEAD
            /*gameObject.GetComponent<Movement>().horizontalSpeed = 3;
            gameObject.GetComponent<Movement>().verticalSpeed = 2;
            gameObject.GetComponent<Renderer>().material.color = Color.white;*/
=======
            Player.GetComponent<Movement>().horizontalSpeed = 3;
            Player.GetComponent<Movement>().verticalSpeed = 2;
            Player.GetComponent<Renderer>().material.color = Color.white;
>>>>>>> origin/master
        }
        if (!allowedTele)
        {
            
            Debug.Log(teleTimer.ToString());
            if (teleTimer <= 0)
            {
                allowedTele = true; 
            }

        }
        if (trapped)
        {
            Debug.Log(TrapTimer.ToString());
            if (TrapTimer <= 0)
            {
                trapped = false;
                Player.GetComponent<Movement>().enabled = true;
                
            }
        }
    }
}

