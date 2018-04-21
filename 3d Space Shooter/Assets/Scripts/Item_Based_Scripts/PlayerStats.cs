using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerStats: CharacterStats{

	public Stat speed;
	public Stat health;


	void Start()
	{
		EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
		speed.addModifier(20);
	}

	void OnEquipmentChanged ( Equipment newItem, Equipment oldItem)
	{
		if (newItem != null)
		{
			armor.addModifier(newItem.armorModifier);
			damage.addModifier(newItem.damageModifier);
			speed.addModifier(newItem.speedModifier);
			maxHealth.addModifier(newItem.healthModifier);
			currentHealth+=newItem.healthModifier;
		}
		if (oldItem != null)
		{
			armor.removeModifier(oldItem.armorModifier);
			damage.removeModifier(oldItem.damageModifier);
			speed.removeModifier(oldItem.speedModifier);
			maxHealth.removeModifier(oldItem.healthModifier);
			currentHealth-=oldItem.healthModifier;
		}
	}
}
