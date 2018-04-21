//This script was made following "Brackeys" Pause Menu tutorial on YouTube
//https://www.youtube.com/watch?v=JivuXdrIHK0&t=633s&ab_channel=Brackeys

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_Menu : MonoBehaviour {

	public GameObject endMenuUI;
	public GameObject player;

	void Start ()
	{
		Time.timeScale = 1f;
	}

	// Update is called once per frame
	void Update () 
	{
		if (!player.activeSelf)
			Die ();
	}

	public void Restart()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene (1);
	}

	void Die()
	{
		endMenuUI.SetActive (true);
		Time.timeScale = 0f;
	}

	public void LoadMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene (0);
	}

	public void QuitGame()
	{
		Debug.Log ("Quitting game...");
		Application.Quit();
	}
}
