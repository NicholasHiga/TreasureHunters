using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    public Transform digMachine;
    public float digDelay = 3.0f;
    float cooldownTimer = 0f;

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
    }
}
