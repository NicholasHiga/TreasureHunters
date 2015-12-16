using UnityEngine;
using System.Collections;

public class CollideChicken : MonoBehaviour {

    public Transform rawChicken;   

    void Start()
    {
        
    }

    void OnTriggerEnter2D()
    {
        if (GameObject.FindGameObjectWithTag("Bullet"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Chicken"));
            Instantiate(rawChicken, transform.position, transform.rotation);
        }
        
    }
}
