using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dig : MonoBehaviour {

    float time = 0;
    public static Image chargeBar;
    public Transform digArea;
    public AudioClip drillSound;

	// Use this for initialization
	void Start () {
        chargeBar = GameObject.Find("Image").GetComponent<Image>();
        chargeBar.fillAmount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
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
        }
	}
}
