using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour {
	
	public GameObject target;
	public void OnAreaActive(GameObject other)
	{
		target = other;
		OnStartActive ();
	}
	public void OnAreaInactive(GameObject other)
	{		
		target = null;
	}
	public virtual void OnStartActive() { }
	public virtual void OnPathCollisionEnter(CollisionChecker.PathCollisionType type) { }
	public virtual void OnPathCollisionExit(CollisionChecker.PathCollisionType type) { }
}
