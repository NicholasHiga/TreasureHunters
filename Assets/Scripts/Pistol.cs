using UnityEngine;
using System.Collections;
using System;

public class Pistol : RangedWeapon
{
	public Pistol(AudioSource _audio, Transform t) : base(_audio, t)
	{
		
	}
	
	public override void Shoot()
	{
		audio.PlayOneShot(shotSound, 1.0f);
		GameObject g = GameObject.Instantiate(Resources.Load("Prefabs/Bullet"), transform.position, Quaternion.identity) as GameObject;
		BulletMove bmScript = g.GetComponent<BulletMove>();
		Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		direction.Normalize();
		bmScript.SetDirection(direction);
	}

	public override void DualShoot()
	{
		Shoot();
	}
}
