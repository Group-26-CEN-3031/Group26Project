using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{ 
    public float speed;
    public float tilt;
    public Boundary boundry;

    public GameObject shot;
    public Transform shotspawn;
    public float fireRate;

    private float nextFire;

    void Update()
    {
       if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject clone = Instantiate(shot, shotspawn.position, shotspawn.rotation);

            GetComponent<AudioSource>().Play();

        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().velocity = movement * speed;


        GetComponent<Rigidbody>().position = new Vector3
            (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundry.xMin, boundry.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundry.zMin, boundry.zMax)
            );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
                                             
    }


}
