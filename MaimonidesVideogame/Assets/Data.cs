using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {

	public int score;

	void Start () {
		DontDestroyOnLoad (this);
		Events.OnGameOver += OnGameOver;
	}
	void OnGameOver(bool win, int score)
	{
		this.score = score;
		if(win)
			UnityEngine.SceneManagement.SceneManager.LoadScene ("WinScreen");
		else
			UnityEngine.SceneManagement.SceneManager.LoadScene ("LoseScreen");
	}

}
