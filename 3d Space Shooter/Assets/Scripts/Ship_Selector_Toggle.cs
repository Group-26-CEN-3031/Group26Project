using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship_Selector_Toggle : MonoBehaviour {

	public GameObject shipSelector;
	public Canvas healthBarDisplay;
	public Image healthBar;

	// Use this for initialization
	void Start ()
	{
		shipSelector.SetActive (false);
		healthBarDisplay.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		//enemy info toggle
		if(Input.GetKeyDown (KeyCode.C))
		{
			if (shipSelector.activeSelf) {
				shipSelector.SetActive (false);
			}
			else
			{
				shipSelector.SetActive (true);
			}
			healthBarDisplay.enabled = !healthBarDisplay.enabled;
		}
	}
}
