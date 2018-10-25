using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour {
	
	public Enemy enemy;
	public Character character;


	void Start () {
		Events.OnAddEnemy += OnAddEnemy;
	}

	void OnAddEnemy (Transform t) {
		Enemy newEnemy = Instantiate (enemy);
		newEnemy.transform.SetParent (transform);
		newEnemy.transform.position = t.localPosition;
		newEnemy.transform.LookAt (character.transform);
	}
}
