using UnityEngine;
using System.Collections;

public class Vax : Character
{
	enum WEAPON
	{
		DUAL_PISTOLS, SHOTGUN, ROCKET_LAUNCHER
	}

	private AudioClip switch_weapon_sound;

	private RangedWeapon[] weapons;
	private uint current_weapon = 0;

	private new AudioSource audio;

	// Use this for initialization
	void Start ()
	{
		audio = GetComponent<AudioSource>();
		weapons = new RangedWeapon[3];
		current_weapon = (uint)WEAPON.DUAL_PISTOLS;

		switch_weapon_sound = Resources.Load("Sounds/Weapons/SwitchWeapon") as AudioClip;

		weapons[0] = new Pistol(audio, transform);
		weapons[0].timeBetweenShots = 0.45f;
		weapons[0].weaponDamage = 20;
		weapons[0].shotSound = Resources.Load("Sounds/Weapons/Pistol") as AudioClip;

		/*weapons[1] = new RangedWeapon(audio);
		weapons[1].timeBetweenShots = 1.5f;
		weapons[1].weaponDamage = 30;
		weapons[1].shotSound = Resources.Load("Sounds/Weapons/Shotgun") as AudioClip;

		weapons[2] = new RangedWeapon(audio);
		weapons[2].timeBetweenShots = 4f;
		weapons[2].weaponDamage = 40;
		weapons[2].shotSound = Resources.Load("Sounds/Weapons/Pistol") as AudioClip;*/
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
			SwitchWeapon(WEAPON.DUAL_PISTOLS);

		if (Input.GetKeyDown(KeyCode.Alpha2))
			SwitchWeapon(WEAPON.SHOTGUN);

		if (Input.GetKeyDown(KeyCode.Alpha3))
			SwitchWeapon(WEAPON.ROCKET_LAUNCHER);

		weapons[current_weapon].Update();
    }

	void SwitchWeapon(WEAPON _weapon)
	{
		audio.PlayOneShot(switch_weapon_sound, 1.0f);
		Debug.Log("Weapon switched to " + (uint)_weapon);
		current_weapon = (uint)_weapon;
	}
}
