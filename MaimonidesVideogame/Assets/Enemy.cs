using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : InteractiveObject {
	
	public MoveToTarget moveToTarget;
	public MoveNoDirection moveNoDirection;
	public ShootToTarget shootToTarget;

	float angle = 0;
	void Start()
	{
		moveToTarget = GetComponent<MoveToTarget> ();
		moveNoDirection = GetComponent<MoveNoDirection> ();
		shootToTarget = GetComponent<ShootToTarget> ();
	}
	void Update () {
		if (target != null) {
			moveToTarget.Updated (target);
		} else {
			moveNoDirection.Updated ();
		}

		Vector3 rot = transform.localEulerAngles;
		rot.y += angle;
		transform.localEulerAngles = rot;

	}
	void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Bullet> ()) {
			//print ("die");
			Destroy (this.gameObject);
		}
	}
	public override void OnStartActive() 
	{ 
		//El personaje entro:
		shootToTarget.ShootAfter(1);
	}
	public override void OnPathCollisionEnter(CollisionChecker.PathCollisionType type) 
	{ 
		//cuando las 2 colisiones estén adentro.
		if (angle != 0) {
			angle = 180;
			return;
		}
		switch (type) {
		case CollisionChecker.PathCollisionType.LEFT:
			angle = 1;
			break;
		case CollisionChecker.PathCollisionType.RIGHT:
			angle = -1;
			break;
		}
	}
	public override void OnPathCollisionExit(CollisionChecker.PathCollisionType type) 
	{ 
		angle = 0;
	}

}
