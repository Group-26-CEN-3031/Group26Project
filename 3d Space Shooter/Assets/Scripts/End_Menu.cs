//This script was made following "Brackeys" Pause Menu tutorial on YouTube
//https://www.youtube.com/watch?v=JivuXdrIHK0&t=633s&ab_channel=Brackeys

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_Menu : MonoBehaviour {

	public GameObject endMenuUI;
	public GameObject healthBar;
	public GameObject player;
	bool inFirst = false;

	// Update is called once per frame
	void Update () 
	{
		if (!player.activeInHierarchy) 
		{
			StartCoroutine (Wait ());
		}
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds (1);
		Pause ();
	}
		
	public void Restart()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene (1);
	}

	void Pause()
	{
		endMenuUI.SetActive (true);
		healthBar.SetActive (false);
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
