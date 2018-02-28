using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow_Player : MonoBehaviour
{
    /*  This script causes the camera to follow the player.
     *  it gets the players transform location and adds
     *  20 to the y value to keep to camera above
     *  */


    public Transform myTarget;
    private Vector3 lockedY = new Vector3(0, 20, 0);


	// Update is called once per frame
	void Update ()
    {
		if(myTarget != null)
        {
            transform.position = myTarget.position + lockedY;

            
        }
	}
}
