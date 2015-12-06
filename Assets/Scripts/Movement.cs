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

        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rotation = Quaternion.LookRotation(transform.position - mousePosition, Vector3.back);
        transform.rotation = rotation;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        GetComponent<Rigidbody2D>().angularVelocity = -0f;

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
