using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public UIManager uiManager;
	CharacterAttack characterAttack;
	Weapons weapons;
	public Animator anim;
	public Rigidbody rb;
	public int jumpForce;
	public float flyForce;
	public float speed;
	public float speed_bird;
	public float speedRotation;
	public int jumpCount = 0;

	public actions action;
	public enum actions
	{
		IDLE,
		WALK,
		PICKUP
	}

	public animalTypes animalType;
	public enum animalTypes
	{
		DOG,
		BIRD
	}

	void Start () {
		characterAttack = GetComponent<CharacterAttack> ();
		weapons = GetComponent<Weapons> ();
	}

	void FixedUpdate () {
		
		float vertical = Input.GetAxis ("Vertical");
		float horizontal = Input.GetAxis ("Horizontal");

		if (vertical != 0) {
			Walk ();
		} else {
			Idle ();
		}

		Vector3 vel;
		if (animalType == animalTypes.BIRD) 
			vel = transform.forward * vertical * speed_bird;
		else
			vel = transform.forward * vertical * speed;
			
		vel.y = rb.velocity.y;
		rb.velocity = vel;

		//Avanzar con fuerza de empuje:
		//rb.AddForce (transform.forward * vertical * speed);

		transform.Rotate(Vector3.up * horizontal * speedRotation);
		transform.localEulerAngles = new Vector3 (0,transform.localEulerAngles.y,0);

		if (Input.GetButtonDown ("ChangeWeapon")) {
			weapons.ChangeWeapon ();
		}
		if (Input.GetButtonDown ("Fire1")) {
			characterAttack.Attack ();
		}
		if (animalType == animalTypes.BIRD) {
			if(Input.GetButton("Jump")){
				
				Vector3 v = rb.velocity;
				v.y = 0;
				rb.velocity = v;

				Vector3 pos = transform.localPosition;
				pos.y += flyForce;
				transform.localPosition = pos;
				print ("sube" + pos.y);
			}
		} else{
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
		if (other.gameObject.tag == "Win") {
			Events.OnGameOver (true, uiManager.coins);
		}
	}
}
