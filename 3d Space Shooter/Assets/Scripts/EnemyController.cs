using UnityEngine;
using UnityEngine.UI;
using System;


<<<<<<< HEAD

=======
>>>>>>> d09081039ed77ece71ce8e8fed45f2a198be8fb8
public class EnemyController : MonoBehaviour
{
	// public GameObject enemy;
	public Transform Player;
	public float Max;
	public float Min;
	public float MoveSpeed;
	// public GameObject self;


<<<<<<< HEAD

	void Start()
	{
=======
	//Shooting variables
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private AudioSource audioSource;
	private float dist;
	private float nextFire;
	private int update;
	private EnemyStats enemyStats;
	public Image enemyHealthBar;

	void Start()
	{
		enemyStats = GetComponent<EnemyStats>();
		fireRate = enemyStats.fireRate.getValue();
		MoveSpeed = enemyStats.speed.getValue();
		Max = enemyStats.engageRange.getValue();
>>>>>>> d09081039ed77ece71ce8e8fed45f2a198be8fb8
		InvokeRepeating("Update", 1, 1);
	}

	void Update()
	{
<<<<<<< HEAD
		transform.LookAt(Player);
			if(Vector3.Distance(transform.position, Player.position) >= Min)
			{
				// Debug.Log(transform.forward);
				if (transform.forward == new Vector3(0,0,0))
				{
					transform.forward = new Vector3(0, 0, 1);
				}
				transform.position += transform.forward*MoveSpeed*Time.deltaTime;
			
				if(Vector3.Distance(transform.position, Player.position) <= Max)
				{
					return;
				}
			}
=======
		//Distance from player
		dist = Vector3.Distance(Player.position, transform.position);
		// Debug.Log (dist);
		float smooth = 1.0f;

		enemyHealthBar.fillAmount = (float)(GetComponent<CharacterStats> ().currentHealth) / (float)(GetComponent<CharacterStats> ().maxHealth.getValue());

		if(dist <= Max)
		{
			System.Random rnd = new System.Random();
			float temp = rnd.Next(0,2);
			update = (int)Math.Round(temp);
        	// Debug.Log("Update: " + update);

			if(update == 1)
			{
				int rotation = rnd.Next(-90,90);
				Quaternion target = Quaternion.Euler(0, rotation, 0);
            	// Debug.Log("Rotation: " + rotation);

				transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			}
			// Debug.Log(transform.forward);
			if (transform.forward == new Vector3(0,0,0))
			{
				transform.forward = new Vector3(0, 0, 1);
			}

			transform.position += transform.forward*MoveSpeed*Time.deltaTime;

			if (Time.time > nextFire) 
			{
				transform.LookAt(Player);

				nextFire = Time.time + fireRate;
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
				audioSource.Play();
			}
			if (dist > Max-2)
			{
				transform.LookAt(Player);
			}
		}
>>>>>>> d09081039ed77ece71ce8e8fed45f2a198be8fb8

	}
}