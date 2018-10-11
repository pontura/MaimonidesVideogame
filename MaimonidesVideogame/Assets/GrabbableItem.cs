using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableItem : InteractiveObject {

	public float speed;

	void Update () {
		if (target != null) {			
			LookAtTarget (target);
			GotoTarget (target);
		}
	}
	public override void OnStartActive() { 
		GetComponent<Collider> ().enabled = false;
		Invoke ("DestroyDelayed", 0.2f);
	}
	public virtual void DestroyDelayed()
	{
		Destroy (this.gameObject);
	}
	void LookAtTarget(GameObject gameObject)
	{
		transform.LookAt (gameObject.transform);
	}
	void GotoTarget(GameObject gameObject)
	{
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}
}
