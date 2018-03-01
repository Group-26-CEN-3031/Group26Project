using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Destroy_By_COntact : MonoBehaviour {


    public GameObject explosion;
    public GameObject playerExplosion;
    public int health = 100;
    public Text playerHealth;

    void OnTriggerEnter(Collider other)
    {
        // If it was a boundry collision, just shrug and move on. 
        if (other.tag == "Boundry" || other.tag == "Enemy")
        {
            return;
        }
        // Lasers have no explosion, and thus should not instantiate one. 
        if(explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            health--;
            if (health == 0)    //object dead
            {
                Destroy(gameObject);
            }
            playerHealth.text = "Health: " + health.ToString();     //update health UI (make sure UI attached to player ship health variable)
        }
        // If contact was with player, add the unique player explosion effect, destroy object.
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            health--;
            if (health == 0)    //object dead
            {
                Destroy(gameObject);
            }
        }

        if(other.tag == "asteroid")     //if contact hit with an asteroid, we want the asteroid to explode
        {
            Destroy(other.gameObject);
        }

    }
}
