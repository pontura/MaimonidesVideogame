using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public int totalEnemy;
	int i;

	void Start () {
		totalEnemy = Random.Range (totalEnemy, totalEnemy+5);
		Invoke ("AddEnemy", 1);
	}
	void AddEnemy () {
		Events.OnAddEnemy(transform);
		i++;
		if (i < totalEnemy) {
			Invoke ("AddEnemy", 1);
		}
		print ("i " + i);
		print ("TotalEnemy " + totalEnemy);

	}
}
