using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	CharacterShooter shooter;
	public Animator anim;
	public Rigidbody rb;
	public int jumpForce;
	public float speed;
	public float speedRotation;
	public int jumpCount = 0;

	public actions action;

	public enum actions
	{
		IDLE,
		WALK
	}

	void Start () {
		shooter = GetComponent<CharacterShooter> ();
	}

	void FixedUpdate () {
		float vertical = Input.GetAxis("Vertical");
		float horizontal = Input.GetAxis("Horizontal");

		if (vertical != 0) {
			Walk ();
		} else {
			Idle ();
		}
		Vector3 vel = transform.forward * vertical * speed;
		vel.y = rb.velocity.y;
		rb.velocity = vel;

		//Avanzar con fuerza de empuje:
		//rb.AddForce (transform.forward * vertical * speed);

		transform.Rotate(Vector3.up * horizontal * speedRotation);

		if (Input.GetButtonDown ("Fire1")) {
			shooter.Shoot ();
		}
		if(Input.GetButtonDown("Jump")){
			if (rb.velocity.y == 0 || jumpCount <= 1) {
				Vector3 v = rb.velocity;
				v.y = 0;
				rb.velocity = v;
				rb.AddForce (Vector3.up * jumpForce);
				jumpCount++;
			}

		}

		else if (rb.velocity.y == 0) {

			jumpCount = 0;
		}
	}

	void Idle()
	{
		if (action == actions.IDLE)
			return;
		action = actions.IDLE;
		anim.Play ("idle");
	}
	void Walk()
	{
		if (action == actions.WALK)
			return;
		action = actions.WALK;
		anim.Play ("walk");
	}
}
