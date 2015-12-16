using UnityEngine;
using System.Collections;

public class CollideChicken : MonoBehaviour {

    public Transform rawChicken;
    public GameObject chicken;

    void Start()
    {
        //GameObject obj = (GameObject)Instantiate(chicken, transform.position, transform.rotation);
    }

    void OnTriggerEnter2D()
    {
        if (GameObject.FindGameObjectWithTag("Bullet"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Chicken"));
            //Instantiate(rawChicken, transform.position, transform.rotation);
        }
        GameObject obj = (GameObject)Instantiate(chicken, transform.position, transform.rotation);
    }
}
