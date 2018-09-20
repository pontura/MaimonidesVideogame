using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaController : MonoBehaviour {

	public InteractiveObject interactiveObject;

	void Start () {
		
	}
	void OnTriggerEnter(Collider other)
	{
		interactiveObject.OnAreaActive (other.gameObject);
	}
	void OnTriggerExit(Collider other)
	{
		interactiveObject.OnAreaInactive (other.gameObject);
	}
}
