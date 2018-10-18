using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour {

	public PathCollisionType type;
	public enum PathCollisionType
	{
		LEFT,
		RIGHT
	}

	public InteractiveObject interactiveObject;

	void OnTriggerEnter(Collider other)
	{
		if( !IsCollisionable(other) )
			return;

		interactiveObject.OnPathCollisionEnter (type);
	}
	void OnTriggerExit(Collider other)
	{
		if( !IsCollisionable(other) )
			return;
		interactiveObject.OnPathCollisionExit (type);
	}
	bool IsCollisionable(Collider other)
	{
		if (other.GetComponent<Enemy> ())
			return false;
		if (other.GetComponent<CollisionChecker> ())
			return false;
		return true;
	}
}
