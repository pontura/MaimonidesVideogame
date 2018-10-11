using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour {
	
	Weapons weapons;
	public Bullet bullet;

	void Start()
	{
		weapons = GetComponent<Weapons> ();
	}
	public void Attack()
	{
		if (weapons.all.Count == 0)
			return;
		else
			OnGunAttack ();
	}
	public void OnGunAttack()
	{
		Bullet newWeapon = Instantiate (bullet);
		newWeapon.transform.localEulerAngles = transform.localEulerAngles;
		Vector3 pos = transform.localPosition + transform.forward*2;
		pos.y += 1;
		newWeapon.transform.localPosition = pos;

	}
}
