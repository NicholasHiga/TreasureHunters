using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {
	public float baseSpeed = 5.0f;
	public Vector3 currentSpeed;

	void Start()
	{
	}

	// Update is called once per frame
	void Update ()
	{
		transform.position += currentSpeed * Time.deltaTime;
	}

	public void SetDirection(Vector3 d)
	{
		d.Normalize();

		float theta = Mathf.Atan2(d.y, d.x);

		currentSpeed.x = baseSpeed * Mathf.Cos(theta);
		currentSpeed.y = baseSpeed * Mathf.Sin(theta);

		transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * theta, Vector3.forward);
	}
}
