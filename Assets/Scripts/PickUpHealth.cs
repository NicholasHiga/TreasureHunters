using UnityEngine;
using System.Collections;

public class PickUpHealth : MonoBehaviour {

	void OnTriggerEnter2D()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            Destroy(GameObject.FindGameObjectWithTag("RawChicken"));
        }
    }
}
