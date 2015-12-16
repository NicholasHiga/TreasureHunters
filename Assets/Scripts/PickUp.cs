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
    int healthPot;
    int RhealthPot;
    bool Raged;
    bool hyper;
    float blinkTimer;

    void Start()
    {
        currentHealth = 1;
        calculatedHealth = currentHealth / maxHealth;
        setHealthBar(calculatedHealth);
        healthPot = 0;
        Raged = false;
        hyper = false;
        blinkTimer = 0;
    }

    void FixedUpdate()
    {
        blinkTimer -= Time.deltaTime;
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
        if (col.gameObject.tag == "Chicken")
        {
            healthPot++;
        }
        else if (col.gameObject.tag == "RedPowerUp")
        {
            
            if (!Raged)
            {
                Enraged();
            }
                Raged = true;
        }
        else if (col.gameObject.tag == "PurplePowerUp")
        {
            if (!hyper)
            {
                Encouraged();
            }
            hyper = true;
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
        blinkTimer = 5;
        if (Raged == false)
        {
            transform.localScale += new Vector3(1f, 1f, 0);
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }
    void Encouraged()
    {
        blinkTimer = 10;
        if (hyper == false)
        {
            gameObject.GetComponent<Movement>().horizontalSpeed = 9;
            gameObject.GetComponent<Movement>().verticalSpeed = 6;
            gameObject.GetComponent<Renderer>().material.color = Color.magenta;
        }
    }
    void State()
    {
        if (Raged)
        {

            Debug.Log(blinkTimer.ToString());
            if (blinkTimer <= 0)
            {
                Raged = false;
            }
        }
        if (!Raged&&!hyper)
        {
            transform.localScale = new Vector3(1f, 1f, 0);
            gameObject.GetComponent<Renderer>().material.color = Color.white;

        }
        if (hyper)
        {
            Debug.Log(blinkTimer.ToString());
            if (blinkTimer <= 0)
            {
                hyper = false;
            }
        }
        if (!hyper&&!Raged)
        {
            gameObject.GetComponent<Movement>().horizontalSpeed = 3;
            gameObject.GetComponent<Movement>().verticalSpeed = 2;
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}

