using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {
    public float speed = 5.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += (transform.rotation * new Vector3(0.0f, speed * Time.deltaTime, 0.0f)) * -1;
    }
}
