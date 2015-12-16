using UnityEngine;
using System.Collections;

public class Vax : Character
{
	enum WEAPON
	{
		DUAL_PISTOLS, ROCKET_LAUNCHER, SHOTGUN
	}

	private AudioClip switch_weapon_sound;

	private RangedWeapon[] weapons;
	private uint current_weapon = 0;
	public bool isDualWielding;

	private new AudioSource audio;

	private float maxDashDistance;
	private float dashSpeed;
	private bool isDashing;
	private Vector3 currentDashSpeed;
	private Vector2 targetDashLocation;
	private Vector2 startingDashLocation;

	// Use this for initialization
	void Start ()
	{
		isDashing = false;
		isDualWielding = false;
		maxDashDistance = 20.0f;
		dashSpeed = 20.0f;

		audio = GetComponent<AudioSource>();
		weapons = new RangedWeapon[2];
		current_weapon = (uint)WEAPON.DUAL_PISTOLS;

		switch_weapon_sound = Resources.Load("Sounds/Weapons/SwitchWeapon") as AudioClip;

		weapons[0] = new Pistol(audio, transform);
		weapons[0].timeBetweenShots = 0.45f;
		weapons[0].weaponDamage = 20;
		weapons[0].shotSound = Resources.Load("Sounds/Weapons/Pistol") as AudioClip;
		weapons[0].parent = this;

		/*weapons[1] = new RangedWeapon(audio);
		weapons[1].timeBetweenShots = 1.5f;
		weapons[1].weaponDamage = 30;
		weapons[1].shotSound = Resources.Load("Sounds/Weapons/Shotgun") as AudioClip;*/
		//weapons[1].parent = this;

		weapons[1] = new RocketLauncher(audio, transform);
		weapons[1].timeBetweenShots = 0.5f;
		weapons[1].weaponDamage = 40;
		weapons[1].shotSound = Resources.Load("Sounds/Weapons/RocketShoot") as AudioClip;
		weapons[1].parent = this;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
			SwitchWeapon(WEAPON.DUAL_PISTOLS);

		if (Input.GetKeyDown(KeyCode.Alpha2))
			SwitchWeapon(WEAPON.ROCKET_LAUNCHER);

		/*if (Input.GetKeyDown(KeyCode.Alpha3))
			SwitchWeapon(WEAPON.ROCKET_LAUNCHER);*/

		if (Input.GetKeyDown(KeyCode.E) && !isDashing)
			DashInDirection(Camera.main.ScreenToWorldPoint(Input.mousePosition));

		if (isDashing)
		{
			transform.position += currentDashSpeed * Time.deltaTime;
			if (Vector2.Distance(transform.position, startingDashLocation) >
				Vector2.Distance(targetDashLocation, startingDashLocation))
			{
				isDashing = false;
				GetComponent<Movement>().enabled = true;
			}
		}

		weapons[current_weapon].Update();
    }

	void SwitchWeapon(WEAPON _weapon)
	{
		audio.PlayOneShot(switch_weapon_sound, 1.0f);
		current_weapon = (uint)_weapon;
	}

	void SetDualWielding(bool _isDualWielding)
	{
		isDualWielding = _isDualWielding;
	}

	void DashInDirection(Vector3 position)
	{
		Vector3 direction = position - transform.position;
		startingDashLocation = transform.position;
		direction.Normalize();

		float theta = Mathf.Atan2(direction.y, direction.x);
		currentDashSpeed.x = dashSpeed * Mathf.Cos(theta);
		currentDashSpeed.y = dashSpeed * Mathf.Sin(theta);

		isDashing = true;
		GetComponent<Movement>().enabled = false;
	}

	public RangedWeapon[] GetWeaponScripts()
	{
		return weapons;
	}
}
