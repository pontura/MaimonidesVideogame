                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapons : MonoBehaviour {

	public Weapon gun;
	public Weapon machineGun;

	public Transform container;

	public List<Weapon> all;
	public Weapon activeWeapon;

	void Start()
	{
		Events.OnGetWeapon += OnGetWeapon;
	}
	void OnDestroy () 
	{
		Events.OnGetWeapon -= OnGetWeapon;
	}
	void OnGetWeapon(Weapon weapon)
	{		
		Weapon newWeapon = null;

		switch (weapon.name) {
		case "Gun":
			newWeapon = Instantiate (gun);
			break;
		case "MachineGun":
			newWeapon = Instantiate (machineGun);
			break;
		}
		activeWeapon = newWeapon;
		all.Add (newWeapon);
		newWeapon.transform.SetParent (container);
		newWeapon.transform.localPosition = Vector3.zero;
		newWeapon.transform.localEulerAngles = Vector3.zero;
		newWeapon.transform.localScale = Vector3.one;
		SetNewActiveWeapon ();
	}
	public void ChangeWeapon()
	{
		if (all.Count < 2)
			return;
		for (int i = 0; i < all.Count; i++) {
			if (all [i] == activeWeapon) {
				if(i<all.Count-1)
					activeWeapon = all [i+1];
				else
					activeWeapon = all [0];

				SetNewActiveWeapon ();
				return;					
			}
		}
	}
	void SetNewActiveWeapon()
	{
		GetComponent<Character> ().PickUp ();
		foreach(Weapon w in all)
			w.gameObject.SetActive (false);
		activeWeapon.gameObject.SetActive (true);
	}
}