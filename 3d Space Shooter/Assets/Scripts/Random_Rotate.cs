using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Rotate : MonoBehaviour {

    public float tumble;

	// make the steroid tumble around
	void Start ()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;


    }
	
	
}
