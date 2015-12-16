using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {
	public float baseSpeed = 5.0f;
	public Vector3 currentSpeed;

	private Vector3 direction = new Vector3(1.0f, 1.0f, 1.0f);
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		//transform.position += 
		//	(transform.rotation * new Vector3(currentSpeed.x * Time.deltaTime,
		//	currentSpeed.y * Time.deltaTime, 0.0f)) * -1;
		transform.position += transform.rotation * currentSpeed * Time.deltaTime;
	}

	public void setDirection(Vector3 d)
	{
		direction = d;
		d.Normalize();

		float theta = Mathf.Atan2(d.y, d.x);

		currentSpeed.x = baseSpeed * Mathf.Cos(theta);
		currentSpeed.y = baseSpeed * Mathf.Sin(theta);
	}
}
