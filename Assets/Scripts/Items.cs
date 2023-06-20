using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Items : MonoBehaviour
{
    public ItemData data;
    public int level;
    public WeaponManager weapon;
    public Gears gear;

    Image Icon;
    TextMeshProUGUI textLevel;
    TextMeshProUGUI textName;
    TextMeshProUGUI textOption;

    void Awake()
    {
        Icon = GetComponentsInChildren<Image>()[1];
        Icon.sprite = data.itemIcon;

        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();
        textLevel = texts[0];
        textName = texts[1];
        textOption = texts[2];
        textName.text = data.itemName;
    }

    void OnEnable()
    {
        textLevel.text = "Lv." + (level + 1);

        switch (data.itemType)
        {
            case ItemData.ItemType.Sword:
            case ItemData.ItemType.Gun:
                textOption.text = string.Format(data.itemDesc, data.damages[level] * 100, data.counts[level]);
                break;
            case ItemData.ItemType.Mangto:
            case ItemData.ItemType.Wings:
                textOption.text = string.Format(data.itemDesc, data.damages[level] * 100);
                break;
            default:
                textOption.text = string.Format(data.itemDesc);
                break;
        }
    } 

    public void OnClick()
    {
        switch(data.itemType)
        {
            case ItemData.ItemType.Sword:
            case ItemData.ItemType.Gun:
                if (level == 0)
                {
                    GameObject newWeapon = new GameObject();
                    weapon = newWeapon.AddComponent<WeaponManager>();
                    weapon.Init(data);
                }
                else 
                {
                    float nextDamage = data.baseDamage;
                    int nextCount = 0;
                    
                    nextDamage += data.baseDamage * data.damages[level];
                    nextCount += data.counts[level];

                    weapon.LevelUp(nextDamage, nextCount);
                }
                level++;
                break;
            case ItemData.ItemType.Mangto:
            case ItemData.ItemType.Wings:
                if (level == 0)
                {
                    GameObject newGear = new GameObject();
                    gear = newGear.AddComponent<Gears>();
                    gear.Init(data);
                }
                else
                {
                    float nextRate = data.damages[level];
                    gear.LevelUp(nextRate);
                }
                level++;
                break;
            case ItemData.ItemType.Elixir:
                GameManager.instance.health = GameManager.instance.maxHealth;
                break;
        }

        if (level == data.damages.Length)
        {
            GetComponent<Button>().interactable = false;
        }
    }
}
