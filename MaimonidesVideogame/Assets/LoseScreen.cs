using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour {

	Data data;
	public Text field;
	void Start()
	{
		data = GameObject.Find ("Data").GetComponent<Data> ();
		field.text = "Perdiste. puntos: " + data.score;
	}
	public void Retry()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Game");
	}
}
