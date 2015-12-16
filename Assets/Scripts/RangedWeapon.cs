using UnityEngine;
using System.Collections;

public abstract class RangedWeapon : MonoBehaviour
{ 
	public AudioClip shotSound;
	public uint weaponDamage;
	public Sprite rangeIndicator;
	public float timeBetweenShots;
	public Vax parent;

	protected new AudioSource audio;
	protected float shotTimer;
	protected Transform transform;

	// Use this for initialization
    public RangedWeapon (AudioSource _audio, Transform t)
	{
		shotTimer = 0;
		audio = _audio;
		transform = t;
    }
	
	// Update is called once per frame
	public void Update ()
	{
		shotTimer -= Time.deltaTime;
		if (Input.GetMouseButton(0) && shotTimer <= 0)
		{
			if (!parent.isDualWielding)
				Shoot();
			else
				DualShoot();

			shotTimer = timeBetweenShots;
		}
	}

	public abstract void Shoot();
	public abstract void DualShoot();
}
