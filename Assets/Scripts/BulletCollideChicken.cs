using UnityEngine;
using System.Collections;

public class BulletCollideChicken : MonoBehaviour {

    public Transform rawChicken;

	void OnCollision2D(Collision2D col)
    {
        if (col.gameObject.name == "Chicken(Clone)")
        {
            Debug.Log("HIT");
            Destroy(col.gameObject);
            Instantiate(rawChicken, transform.position, transform.rotation);
        }
    }
}
