using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Text scoreField;
	int coins = 0;

	void Start () {
		Events.OnAddCoin += OnAddCoin;
	}

	void OnAddCoin (int value) {
		print ("agarro una coin " + value);
		coins = coins + value;

		scoreField.text = coins.ToString();
	}
}
