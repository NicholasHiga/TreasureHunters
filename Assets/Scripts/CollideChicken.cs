using UnityEngine;
using System.Collections;

public class CollideChicken : MonoBehaviour {

    public Transform rawChicken;

	public void DropRawChicken()
	{
		Destroy(GameObject.FindGameObjectWithTag("Chicken"));
		Instantiate(rawChicken, transform.position, transform.rotation);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Missile")
        {
			DropRawChicken();
        }
    }
}
