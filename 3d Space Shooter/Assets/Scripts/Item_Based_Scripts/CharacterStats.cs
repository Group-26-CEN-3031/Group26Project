using UnityEngine;

[System.Serializable]

public class CharacterStats : MonoBehaviour
{
	public Stat maxHealth;
	public int currentHealth{get; set;}

	public Stat damage;
	public Stat armor;

	void Awake()
	{	
		maxHealth.addModifier(10);
		currentHealth = maxHealth.getValue();
		// armor.addModifier(1);
		// damage.addModifier(1);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.T))
		{
			armor.addModifier(10);
		}
	}

	public void takeDamage(int damage)
	{
		damage = damage - armor.getValue();
		if (damage < 0)
		{
			damage = 0;
		}
		currentHealth -= damage;
		// Debug.Log(transform.name + " takes " + damage + " damage.");

		if(currentHealth <= 0)
		{
			Die();
		}


	}
	// Not used currently.
	public virtual void Die()
	{
		// Die in some way
		// Meant to be overriden. 
		Debug.Log(transform.name + " dies.");
	}
}