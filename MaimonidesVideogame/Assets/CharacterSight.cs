using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSight : MonoBehaviour
{
	public GameObject target;
	private LineRenderer line; 

	void Start () {
		line = this.gameObject.AddComponent<LineRenderer>();
		line.SetWidth(.1f, .1f);
		line.SetVertexCount(2);
	}

	void Update () {
			line.SetPosition(0, transform.position);
			line.SetPosition(1, target.transform.position);
	}
}
