using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour {

	//Given that this we don't have saving implemented yet, this will just load the "Level_1" scene
	public void StartGame ()
	{
		//Load the next scene in the index
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void QuitGame()
	{
		Application.Quit ();
		Debug.Log ("QUIT!");
	}

}
