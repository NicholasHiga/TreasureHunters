using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    public Transform digMachine;
    public float digDelay = 3.0f;
    float cooldownTimer = 0f;

	// Make this an enum later, when there's pretty much 360 degree freedom
	bool directionFacing = false; // 0 = left, 1 = right

    void FixedUpdate()
    {
        cooldownTimer -= Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
            gameObject.transform.position += new Vector3(-horizontalSpeed * Time.fixedDeltaTime, 0, 0);

        if (Input.GetKey(KeyCode.D))
            gameObject.transform.position += new Vector3(horizontalSpeed * Time.fixedDeltaTime, 0, 0);

        if (Input.GetKey(KeyCode.W))
            gameObject.transform.position += new Vector3(0, verticalSpeed * Time.fixedDeltaTime, 0);

        if (Input.GetKey(KeyCode.S))
            gameObject.transform.position += new Vector3(0, -verticalSpeed * Time.fixedDeltaTime, 0);
        if (Input.GetKey(KeyCode.Space) && cooldownTimer <= 0)
        {
            cooldownTimer = digDelay;
            Instantiate(digMachine, transform.position, transform.rotation);
        }

		directionFacing = Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.localPosition.x;

		if ((!directionFacing && transform.localScale.x >= 0)
			|| (directionFacing && transform.localScale.x <= 0))
			transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
