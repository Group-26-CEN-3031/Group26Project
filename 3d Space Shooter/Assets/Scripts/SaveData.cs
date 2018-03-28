using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SaveData {

    public static SaveData current;

    //Save Game Data
    public int playerHealth;
    //public Vector3 playerPos;                 //Declare in Player_Controller
    //public Quaternion playerRot;              //Declare in Player_Controller

    //To Do: store multiple enemies in list
    public int enemyHealth;
    //public Vector3 enemyPos;                  //Declare in Enemy_Controller
    //public Quaternion enemyRot;               //Declare in Enemy_Controller

    /* Persistence through scenes
     * Can only be used in MonoBehaviour
     * !SaveData won't work as MonoBehaviour!
    void Awake ()
     {
         if(current == null)
         {
            DontDestroyOnLoad(gameObject);
            current = this;
         }
         else if(current != this)
         {
             Destroy(gameObject);
         }
     }
     */

    public void Save ()
    {
        playerHealth = GameObject.Find("Player_Ship").GetComponent<Destroy_By_COntact>().health;
        //playerPos = GameObject.Find("Player_Ship").transform.position;
        //playerRot = GameObject.Find("Player_Ship").transform.rotation;

        enemyHealth = GameObject.Find("Enemy Ship 1").GetComponent<Destroy_By_COntact>().health;
        //enemyPos = GameObject.Find("Enemy Ship 1").transform.position;
        //enemyRot = GameObject.Find("Enemy Ship 1").transform.rotation;
    }

    //
    public void Load()
    {
        GameObject.Find("Player_Ship").GetComponent<Destroy_By_COntact>().health = SaveLoad.savedGames[0].playerHealth;
        //GameObject.Find("Player_Ship").transform.position = SaveLoad.savedGames[0].playerPos;
        //GameObject.Find("Player_Ship").transform.rotation = SaveLoad.savedGames[0].playerRot;

        GameObject.Find("Enemy Ship 1").GetComponent<Destroy_By_COntact>().health = SaveLoad.savedGames[0].enemyHealth;
        //GameObject.Find("Enemy Ship 1").transform.position = SaveLoad.savedGames[0].enemyPos;
        //GameObject.Find("Enemy Ship 1").transform.rotation = SaveLoad.savedGames[0].enemyRot;
    }
}