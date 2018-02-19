using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_By_COntact : MonoBehaviour {


    public GameObject explosion;
    public GameObject playerExplosion;

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
        }
        // If contact was with player, add the unique player explosion effect, destroy object.
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
