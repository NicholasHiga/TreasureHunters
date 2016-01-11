using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    public GameObject digMachine;
    public float digDelay = 0.3f;
    float cooldownTimer = 0f;

	public KeyCode upMove, downMove, leftMove, rightMove;

	// Make this an enum later, when there's pretty much 360 degree freedom
	bool directionFacing = false; // 0 = left, 1 = right

    void FixedUpdate()
    {
        cooldownTimer -= Time.deltaTime;

        if (Input.GetKey(leftMove))
            gameObject.transform.position += new Vector3(-horizontalSpeed * Time.fixedDeltaTime, 0, 0);

        if (Input.GetKey(rightMove))
            gameObject.transform.position += new Vector3(horizontalSpeed * Time.fixedDeltaTime, 0, 0);

        if (Input.GetKey(upMove))
            gameObject.transform.position += new Vector3(0, verticalSpeed * Time.fixedDeltaTime, 0);

        if (Input.GetKey(downMove))
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
