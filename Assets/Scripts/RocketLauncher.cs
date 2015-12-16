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
		GameObject g = GameObject.Instantiate(Resources.Load("Prefabs/Missile"), transform.position, Quaternion.identity) as GameObject;
		MissileMove mmScript = g.GetComponent<MissileMove>();
		Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		direction.Normalize();
		mmScript.SetDirection(direction);
		mmScript.SetExplosionLocation(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

	public override void DualShoot()
	{
		Shoot();
	}	
}
