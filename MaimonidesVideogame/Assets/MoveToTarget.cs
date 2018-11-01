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
		if (gameObject.transform.localPosition.y > 2)
			return;
		transform.LookAt (gameObject.transform);
	}
	void GotoTarget(GameObject gameObject)
	{
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}
}
