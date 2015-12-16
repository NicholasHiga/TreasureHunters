using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {
	float  currentHealth = 0;
	float maxHealth = 100;
	float calculatedHealth;
	public GameObject HealthBar;


	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag=="Chicken")
		{

			currentHealth += 100;
			calculatedHealth = currentHealth / maxHealth;
			setHealthBar(calculatedHealth);
		}
	}
	public void setHealthBar(float myHealth)
	{
		HealthBar.transform.localScale = new Vector3 (myHealth, HealthBar.transform.localScale.y, HealthBar.transform.localScale.z);
	}
}
