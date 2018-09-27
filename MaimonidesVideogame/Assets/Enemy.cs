using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : InteractiveObject {
	
	public float speed;

	void Update () {
		if (target != null) {
			LookAtTarget (target);
			GotoTarget (target);
		}
	}
	void LookAtTarget(GameObject gameObject)
	{
		transform.LookAt (gameObject.transform);
	}
	void GotoTarget(GameObject gameObject)
	{
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.GetComponent<Weapon>())
			Destroy (this.gameObject);
	}

}
