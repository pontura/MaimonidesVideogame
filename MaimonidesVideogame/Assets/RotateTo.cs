using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTo : MonoBehaviour {

	public void Updated (float angle_to) {
		transform.Rotate( Vector3.Lerp(transform.localEulerAngles, new Vector3(0,angle_to,0), 0.1f));
	}
}
