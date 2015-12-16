using UnityEngine;
using System.Collections;

public class CollideChicken : MonoBehaviour {

    public Transform rawChicken;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(GameObject.FindGameObjectWithTag("Chicken"));
            Instantiate(rawChicken, transform.position, transform.rotation);
        }
    }
}
