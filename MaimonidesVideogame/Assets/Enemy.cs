using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : InteractiveObject {
	
	public MoveToTarget moveToTarget;
	public MoveNoDirection moveNoDirection;

	void Update () {
		if (target != null) {
			moveToTarget.Updated (target);
		} else {
			moveNoDirection.Updated ();
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.GetComponent<Bullet>())
			Destroy (this.gameObject);
	}

}
