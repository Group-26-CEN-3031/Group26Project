using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerStats: CharacterStats{

	void Start()
	{
		EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
	}

	void OnEquipmentChanged ( Equipment newItem, Equipment oldItem)
	{
		if (newItem != null)
		{

			armor.addModifier(newItem.armorModifier);
			damage.addModifier(newItem.damageModifier);
		}
		if (oldItem != null)
		{

			armor.removeModifier(oldItem.armorModifier);
			damage.removeModifier(oldItem.damageModifier);
		}
	}
}