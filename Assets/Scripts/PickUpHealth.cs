using UnityEngine;
using System.Collections;

public class PickUpHealth : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(GameObject.FindGameObjectWithTag("RawChicken"));
        }
    }
}
