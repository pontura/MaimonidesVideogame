using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooter : MonoBehaviour {

	public Weapon weapon;

	public void Shoot()
	{
		Weapon newWeapon = Instantiate (weapon);
		newWeapon.transform.localEulerAngles = transform.localEulerAngles;
		Vector3 pos = transform.localPosition + transform.forward*2;
		pos.y += 1;
		newWeapon.transform.localPosition = pos;

	}
}
