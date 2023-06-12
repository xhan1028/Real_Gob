using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Menu Object/ItemData")]
public class ItemData : ScriptableObject
{
	public enum ItemType { Sword, Gun, Mangto, Wings, Elixir }

	[Header("# Item")]
	public ItemType itemType;
	public int itemId; 
	public string itemName;
	[TextArea]
	public string itemDesc;
	public Sprite itemIcon;

	[Header("# Level")]
	public float baseDamage;
	public int baseCount;
	public float[] damages;
	public int[] counts;

	[Header("# Weapon")]
	public GameObject projectile;
}
