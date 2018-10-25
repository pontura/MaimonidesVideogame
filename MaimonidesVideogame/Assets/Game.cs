using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public Coin coin;
	public Enemy enemy;
	public int totalCoins = 50;
	public int totalEnemies = 10;

	void Start () {
		for (int a = 0; a < totalCoins; a++) {
			Coin newCoin = Instantiate (coin);
			newCoin.transform.SetParent (transform);
			newCoin.transform.position = new Vector3 (Random.Range (-23, 23), 5, Random.Range (-23, 23));
		}
	}
}
