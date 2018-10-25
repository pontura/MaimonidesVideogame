using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Text scoreField;
	public Text lifeField;
	int coins = 0;
	int life = 10;

	void Start () {
		Events.OnAddCoin += OnAddCoin;
		Events.OnCharacterHitted += OnCharacterHitted;
		SetFields ();
	}
	void OnAddCoin (int value) {
		print ("agarro una coin " + value);
		coins = coins + value;
		SetFields ();
	}
	void OnCharacterHitted(int damage)
	{
		life = life - damage;
		SetFields ();
	}
	void SetFields()
	{
		scoreField.text = coins.ToString();
		lifeField.text = life.ToString ();
	}
}
