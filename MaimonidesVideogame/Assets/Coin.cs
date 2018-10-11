﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : GrabbableItem {

	public override void DestroyDelayed()
	{
		Events.OnAddCoin (1);

		//llama a esta función un nivel arriba: (que está en GrabbableItem)
		base.DestroyDelayed ();
	}
}
