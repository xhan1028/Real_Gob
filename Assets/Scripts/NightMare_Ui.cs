using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightMare_Ui : MonoBehaviour
{
	public Boss_Option boss_option;
	public Slider slider;

	void Start()
	{
		slider.maxValue = boss_option.health;
	}

	void Update()
	{
		slider.value = boss_option.health;
	}
}
