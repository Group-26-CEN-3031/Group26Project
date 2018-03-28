using UnityEngine;
 using UnityEngine.UI;

[System.Serializable]
public class EnemyController : MonoBehaviour
{
	// public GameObject enemy;
	public Transform Player;
	public float Max;
	public float Min;
	public float MoveSpeed;


	void Start()
	{
		InvokeRepeating("Update", 1, 1);
	}

	void Update()
	{
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

	}
}