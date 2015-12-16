using UnityEngine;
using System.Collections;

public class MissileMove : MonoBehaviour
{
	public GameObject explosion;
	public int damage;
	private float baseSpeed = 8.0f;
	private Vector3 currentVecSpeed;
	private Vector2 explosionLocation;
	private Vector2 startingLocation;

	// Update is called once per frame
	void Update()
	{
		transform.position += currentVecSpeed * Time.deltaTime;

		if (Vector2.Distance(transform.position, startingLocation) >
			Vector2.Distance(explosionLocation, startingLocation))
		{
			//Vector4 boundaries = explosion.GetComponent<SpriteRenderer>().sprite.border;
			//Vector3 pos = new Vector3();
			//pos.x = transform.position.x + (boundaries.z - boundaries.x);
			//pos.y = transform.position.y + (boundaries.y - boundaries.w);
			Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, 0.5f);
			for (int i = 0; i < col.Length; i++)
			{			
				if (col[i].tag == "Chicken")
				{
					col[i].gameObject.GetComponent<CollideChicken>().DropRawChicken();
					Debug.Log("Detected");
				}

			}

			Instantiate(explosion, gameObject.transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}

	public void SetDirection(Vector3 d)
	{
		d.Normalize();

		float theta = Mathf.Atan2(d.y, d.x);

		currentVecSpeed.x = baseSpeed * Mathf.Cos(theta);
		currentVecSpeed.y = baseSpeed * Mathf.Sin(theta);

		transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * theta, Vector3.forward);
	}

	public void SetExplosionLocation(Vector3 v)
	{
		explosionLocation = v;
		startingLocation = transform.position;
	}
}
