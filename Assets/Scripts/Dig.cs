using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dig : MonoBehaviour
{

    float time = 0;
    public Image chargeBar;
    public Transform digArea;
    public Transform purplePowerUp;
    public Transform redPowerUp;
    public Transform treasure;
    public AudioClip drillSound;
    private int number;

    // Use this for initialization
    void Start()
    {
        chargeBar = gameObject.transform.FindChild("Canvas").FindChild("Image").GetComponent<Image>();
        chargeBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        number = Random.Range(1, 4);
        if (time >= 0.2f)
        {
            // GetComponent<AudioSource>().PlayOneShot(drillSound, 0.3f);
            chargeBar.fillAmount += 0.01f;
            //time = 0;           
        }
        if (chargeBar.fillAmount == 1.0f)
        {
            Destroy(gameObject);
            Instantiate(digArea, transform.position, transform.rotation);
            if (number == 1)
            {
                Instantiate(purplePowerUp, transform.position, transform.rotation);
            }
            if (number == 2)
            {
                Instantiate(redPowerUp, transform.position, transform.rotation);
            }
            if (number == 3)
            {
                Instantiate(treasure, transform.position, transform.rotation);
            }
        }
    }
}
