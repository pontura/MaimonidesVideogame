using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour {

	public float speed;

	public void Updated (GameObject target) {
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
}
