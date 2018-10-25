using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	
	float speed = 40;
	Rigidbody rb;
	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		Invoke ("Die", 1);
	}
	void Die()
	{
		Destroy (this.gameObject);
	}
	void Update () {
		Vector3 vel = transform.forward * speed;
		rb.velocity = vel;
	}
	void OnTriggerEnter(Collider other)
	{
		Destroy (this.gameObject);
	}
}
