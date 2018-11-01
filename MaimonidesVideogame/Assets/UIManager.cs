using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Image bar;
	public Text scoreField;
	public Text lifeField;
	public int coins = 0;
	int life = 10;

	void Start () {
		Events.OnAddCoin += OnAddCoin;
		Events.OnCharacterHitted += OnCharacterHitted;
		SetFields ();
	}
	void OnDestroy () {
		Events.OnAddCoin -= OnAddCoin;
		Events.OnCharacterHitted -= OnCharacterHitted;
	}
	void OnAddCoin (int value) {
		coins = coins + value;
		SetFields ();
	}
	void OnCharacterHitted(int damage)
	{
		life = life - damage;
		bar.fillAmount = (float)life / 10;
		SetFields ();
		if (life <= 0)
			Events.OnGameOver(false, coins);
	}
	void SetFields()
	{
		scoreField.text = coins.ToString();
		lifeField.text = life.ToString ();
	}
}
