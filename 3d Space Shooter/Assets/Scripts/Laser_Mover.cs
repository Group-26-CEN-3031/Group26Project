using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Mover : MonoBehaviour
{
    public float speed;

	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody>().velocity = -transform.forward * speed;



    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
