using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableWeapon : GrabbableItem {

	public Weapon weapon;

	public override void DestroyDelayed()
	{
		Events.OnGetWeapon (weapon);
		base.DestroyDelayed ();
	}

}
