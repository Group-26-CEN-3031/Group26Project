using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;


public class EnemyController : MonoBehaviour
{
	// public GameObject enemy;
	public Transform Player;
	public float Max;
	public float MoveSpeed;


	//Shooting variables
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private AudioSource audioSource;
	private float dist;
	private float nextFire;
	private float Min = 0;
	private int update;
	private int randomBuild;
	private CharacterStats stats;

	//Health, armor
	private int[,] enemyStats = new int [,] { {10,0}, {14,0}, {6,0} };

	//Speed, fireRate, Max
	private float[,] movement = new float[,] { {12f,1f,40f}, {8f,2f,60f}, {16f,0.5f,30f} };

	void Start()
	{
		stats = GetComponent<CharacterStats> ();

		//Debug.Log (enemyStats.Length);

		//Get random build type
		randomBuild = UnityEngine.Random.Range (0, 3);

		//Assign stats based off of build
		stats.SetHealth(enemyStats[randomBuild, 0] - 10);
		stats.armor.addModifier(enemyStats[randomBuild, 1]);
		MoveSpeed = movement [randomBuild, 0];
		fireRate = movement [randomBuild, 1];
		Max = movement [randomBuild, 2];
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
