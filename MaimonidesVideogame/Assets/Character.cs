using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
	public Rigidbody rb;
	public int jumpForce;
	public float speed;
	public float speedRotation;
	public int jumpCount = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// fixedUpdate calcula la logica de la fisica entre un frame y otro. PARA USAR COSAS PARA LA FISICA
	void FixedUpdate () {
		float vertical = Input.GetAxis("Vertical");
		float horizontal = Input.GetAxis("Horizontal");
		rb.AddForce (transform.forward * vertical * speed);
		//rb.AddForce (Vector3.left * horizontal * speed);
		transform.Rotate(Vector3.up * horizontal * speedRotation);

		if(Input.GetKeyDown(KeyCode.Space)){
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
