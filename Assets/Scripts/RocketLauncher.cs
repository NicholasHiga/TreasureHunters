using UnityEngine;
using System.Collections;

public class RocketLauncher : RangedWeapon
{
	public RocketLauncher(AudioSource _audio, Transform t) : base(_audio, t)
	{

	}


	public override void Shoot()
	{
		audio.PlayOneShot(shotSound, 1.0f);
		GameObject g = GameObject.Instantiate(Resources.Load("Prefabs/Missile"), transform.position, transform.rotation) as GameObject;
		BulletMove mmScript = g.GetComponent<BulletMove>();
		Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		direction.Normalize();
		mmScript.setDirection(direction);
	}
}
