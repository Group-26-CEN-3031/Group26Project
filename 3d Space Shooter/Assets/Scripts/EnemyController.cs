using UnityEngine;
using UnityEngine.UI;
using System;


public class EnemyController : MonoBehaviour
{
	// public GameObject enemy;
	public Transform Player;
	public float Max;
	public float Min;
	public float MoveSpeed;
	// public GameObject self;


	//Shooting variables
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private AudioSource audioSource;
	private float dist;
	private float nextFire;
	private int update;
	private EnemyStats enemyStats;

	void Start()
	{
		enemyStats = GetComponent<EnemyStats>();
		fireRate = enemyStats.fireRate.getValue();
		MoveSpeed = enemyStats.speed.getValue();
		Max = enemyStats.engageRange.getValue();
		InvokeRepeating("Update", 1, 1);
	}

	void Update()
	{
		//Distance from player
		dist = Vector3.Distance(Player.position, transform.position);
		// Debug.Log (dist);
		float smooth = 1.0f;

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

	}
}