using UnityEngine;
using System.Collections;

public class RangedWeapon
{ 
	public AudioClip shotSound;
	public uint weaponDamage;
	public Sprite rangeIndicator;
	public float timeBetweenShots;

	protected new AudioSource audio;
	protected float lastTimeShot;

	// Use this for initialization
    public RangedWeapon (AudioSource _audio)
	{
		lastTimeShot = Time.time - timeBetweenShots;
		audio = _audio;
	}
	
	// Update is called once per frame
	public void Update ()
	{
		if (Input.GetMouseButton(0) && Time.time - lastTimeShot >= timeBetweenShots)
		{
			audio.PlayOneShot(shotSound, 1.0f);
			lastTimeShot = Time.time;
		}
	}
}
