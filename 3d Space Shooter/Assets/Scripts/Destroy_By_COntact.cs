using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]

public class Destroy_By_COntact : MonoBehaviour {


    public GameObject explosion;
    public GameObject playerExplosion;

    public CharacterStats myStats;
    public int health;
    public Text playerHealth;
    public GameObject self;

    void Start()
    {
        myStats = GetComponent<CharacterStats>();
        health = myStats.currentHealth;
        self = this.gameObject;
    }
    // Called whenever a collision happens and checks to see what the object collided with. 
    // Example if a laser collided with an asteroid, the asteroid would call this script and run the laser if statement.
    // The laser would run the asteroid if statement.
    void OnTriggerEnter(Collider other)
    {
        //take no damage when colliding with pickup/station
        if (other.tag == "scrap" || other.tag == "Station" || other.tag == "coin")
        {
            return;
        }

        // If it was a boundry collision, just shrug and move on. 
        if (other.tag == "Enemy")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            myStats.takeDamage(1);
            health = myStats.currentHealth;
            // Debug.Log(self.tag + " Collided with Enemy.");

 
            if(self.tag == "Player")
            {
                if (health < 0)    //object dead
                {
                    gameObject.SetActive(false);
                }
                playerHealth.text = "Health: " + health.ToString(); 
            }
            else if (health < 0)    //object dead
            {
                Destroy(gameObject);
            }
            return;
        }
        // Lasers have no explosion, and thus should not instantiate one. 
        if(other.tag == "Laser")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            myStats.takeDamage(other.GetComponent<CharacterStats>().damage.getValue());
            // Debug.Log(self.tag + " Collided with Laser.");
            health = myStats.currentHealth;
  
            //update health UI (make sure UI attached to player ship health variable)
            if(self.tag == "Player")
            {   
                if (health < 0)    //object dead
                {
                    gameObject.SetActive(false);
                }
                playerHealth.text = "Health: " + health.ToString(); 
            }
            else if (health < 0)    //object dead
            {
                Destroy(gameObject);

				if (self.tag == "Enemy") 
				{
					EnemySpawner.killEnemy ();
					int choice = Random.Range(0,101);       //probability generation

					if(choice <= 30)    //just gold
						Instantiate(Resources.Load("goldCoins"), transform.position, Quaternion.Euler(90,0,0));
					else if(choice > 30 && choice <= 70)    //just scrap
						Instantiate(Resources.Load("Mus_2"), transform.position, transform.rotation);
					else if (choice > 70 && choice <= 90)   //1 gold + 2 scrap
					{
						Instantiate(Resources.Load("goldCoins"), transform.position, Quaternion.Euler(90, 0, 0));
						Instantiate(Resources.Load("Mus_2"), transform.position + Vector3.left *3, transform.rotation);
						Instantiate(Resources.Load("Mus_1"), transform.position + Vector3.right *3, transform.rotation);
					}
					else    //2 gold + 4 scrap
					{
						Instantiate(Resources.Load("goldCoins"), transform.position, Quaternion.Euler(90, 0, 0));
						Instantiate(Resources.Load("goldCoins"), transform.position, Quaternion.Euler(90, 0, 0));
						Instantiate(Resources.Load("Mus_1"), transform.position + Vector3.left *3, transform.rotation);
						Instantiate(Resources.Load("Mus_2"), transform.position + Vector3.right * 3, transform.rotation);
						Instantiate(Resources.Load("Mus_3"), transform.position + Vector3.forward *3, transform.rotation);
						Instantiate(Resources.Load("Mus_4"), transform.position + Vector3.back * 3, transform.rotation);
					}
				}
            }
        }
        // If contact was with player, add the unique player explosion effect, destroy object.
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            myStats.takeDamage(1);
            health = myStats.currentHealth;
            // Debug.Log(self.tag + " Collided with Player.");

            if (health < 0)    //object dead
            {
				gameObject.SetActive(false);
            }
        }

        if(other.tag == "asteroid")     //if contact hit with an asteroid, we want the asteroid to explode
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            myStats.takeDamage(1);
            health = myStats.currentHealth;
            // Debug.Log(self.tag + " Collided with asteroid.");


            if(self.tag == "Player")
            {
                if (health < 0)    //object dead
                {
                    gameObject.SetActive(false);
                }
                playerHealth.text = "Health: " + health.ToString(); 
            }
            else if (health < 0)    //object dead
            {
                Destroy(gameObject);
            }

        }

    }
}