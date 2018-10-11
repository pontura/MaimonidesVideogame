using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNoDirection : MonoBehaviour {

	public float speed;
	public float randomRotation;
	float rotationValue = 0;
	float num;

	public void Updated () {
		num += Time.deltaTime;
		if (num > 1) {
			SetNewValues ();
			num = 0;
		}
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
		transform.Rotate ( transform.up * rotationValue);
	}

	void SetNewValues()
	{
		rotationValue = Random.Range (-randomRotation, randomRotation) / 10;
		speed = Random.Range (0, 40)/10;
	}
}
