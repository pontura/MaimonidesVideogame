using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events {

	public static System.Action<Transform> OnAddEnemy = delegate {};
	public static System.Action<int> OnCharacterHitted = delegate {};
	public static System.Action<int> OnAddCoin = delegate {};
	public static System.Action<Weapon> OnGetWeapon = delegate {};

}
