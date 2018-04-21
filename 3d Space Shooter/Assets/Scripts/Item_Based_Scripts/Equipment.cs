using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName="Inventory/Equipment")]

public class Equipment : Item
{

	public EquipmentSlot equipSlot;
	public int armorModifier;
	public int damageModifier;
	public int healthModifier;
	public int speedModifier;

	public override void Use()
	{
		base.Use();
		//Equip Item
		// Remove Item from Inventory
		EquipmentManager.instance.Equip(this);
		RemoveFromInventory();
	}


}

public enum EquipmentSlot{Engine, Hull, Weapon, Shields, Cargo}