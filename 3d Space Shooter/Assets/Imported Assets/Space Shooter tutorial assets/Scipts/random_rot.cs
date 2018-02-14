using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_rot : MonoBehaviour {

    public float tumble;

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }
}
