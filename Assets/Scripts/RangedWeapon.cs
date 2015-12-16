using UnityEngine;
using System.Collections;

public abstract class RangedWeapon
{ 
	public AudioClip shotSound;
	public uint weaponDamage;
	public Sprite rangeIndicator;
	public float timeBetweenShots;

	protected new AudioSource audio;
	protected float lastTimeShot;
	protected Transform transform;

	// Use this for initialization
    public RangedWeapon (AudioSource _audio, Transform t)
	{
		lastTimeShot = Time.time - timeBetweenShots;
		audio = _audio;
		transform = t;
	}
	
	// Update is called once per frame
	public void Update ()
	{
		if (Input.GetMouseButton(0) && Time.time - lastTimeShot >= timeBetweenShots)
		{
			Shoot();
			lastTimeShot = Time.time;
			Debug.Log("Time: " + Time.time + " lastTimeShot: " + lastTimeShot + " " + (Time.time - lastTimeShot));
		}
	}

	public abstract void Shoot();
}
