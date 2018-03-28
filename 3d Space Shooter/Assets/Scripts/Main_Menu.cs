//This script was made following "Brackeys" Start Menu tutorial on YouTube
//https://www.youtube.com/watch?v=zc8ac_qUXQY&ab_channel=Brackeys

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour {

	//Given that this we don't have saving implemented yet, this will just load the "Level_1" scene
	public void StartGame ()
	{
        SaveData.current = new SaveData();
        //Load the next scene in the index
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void QuitGame()
	{
		Debug.Log ("Quitting game...");
		Application.Quit ();
	}

}
