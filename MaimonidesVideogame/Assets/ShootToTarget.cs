using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToTarget : MonoBehaviour {

	Enemy enemy;
	public Bullet bullet;

	void Start()
	{
		enemy = GetComponent<Enemy> ();
	}
	public void ShootAfter(float delay)
	{
		Invoke ("Shoot", delay);
	}
	public void Shoot()
	{
		if (enemy.target == null)
			return;
		Invoke ("Shoot", 0.5f);
		Bullet newWeapon = Instantiate (bullet);
		newWeapon.transform.localEulerAngles = transform.localEulerAngles;
		Vector3 pos = transform.localPosition + transform.forward*2;
		pos.y += 1;
		newWeapon.transform.localPosition = pos;
	}

}
