using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    public float AmmoMax;
    public float ammoCount;
    public float fireDelay = 0.5f;
    float cooldownTimer = 0;
    public GameObject bulletPrefab;
    public Vector3 bulletOffset = new Vector3(0f, 0.5f, 0f);
    // Update is called once per frame
    void Start()
    {
        AmmoMax = 10;
        //ammoCount = AmmoMax;
    }
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            cooldownTimer = fireDelay;
            Vector3 offset = transform.rotation * bulletOffset;
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            //ammoCount--;
        }
        //SetText();
    }
    //void SetText()
    //{
    //    BulletText.text = ammoCount.ToString() + " / " + AmmoMax.ToString();
    //    if (Input.GetButton("Fire1") && ammoCount <= 0)
    //        StatusUpdate.text = "Find some Ammo";

    //}
}
