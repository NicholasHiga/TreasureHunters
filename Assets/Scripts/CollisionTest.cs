using UnityEngine;
using System.Collections;

public class CollisionTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Dug(Clone)")
        {
            Debug.Log("HIT");
            Destroy(col.gameObject);
        }
    }
}
