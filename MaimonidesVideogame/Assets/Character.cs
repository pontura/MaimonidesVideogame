using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	CharacterAttack characterAttack;
	Weapons weapons;
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
		WALK,
		PICKUP
	}

	void Start () {
		characterAttack = GetComponent<CharacterAttack> ();
		weapons = GetComponent<Weapons> ();
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

		if (Input.GetButtonDown ("ChangeWeapon")) {
			weapons.ChangeWeapon ();
		}
		if (Input.GetButtonDown ("Fire1")) {
			characterAttack.Attack ();
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
		if (action == actions.PICKUP)
			return;		
		action = actions.IDLE;
		anim.Play ("idle");
	}
	void Walk()
	{
		if (action == actions.WALK)
			return;
		if (action == actions.PICKUP)
			return;
		action = actions.WALK;
		anim.Play ("walk");
	}
	public void PickUp()
	{
		action = actions.PICKUP;
		anim.Play ("pickup");
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Bullet> ()) {
			Events.OnCharacterHitted (1);
		}
	}
}
