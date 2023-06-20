using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudUi : MonoBehaviour
{
    TextMeshProUGUI resourceText;
    public enum InfoType { Exp, Level, Kill, Time, Health }
    public InfoType type;

   // Text myText;
    Slider mySlider;

    void Awake()
    {
        resourceText = GetComponent<TextMeshProUGUI>();
        mySlider = GetComponent<Slider>();
    }

    void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                float curExp = GameManager.instance.exp;
                float maxExp = GameManager.instance.nextExp[Mathf.Min(GameManager.instance.level, GameManager.instance.nextExp.Length-1)];
                mySlider.value = curExp / maxExp;
                break;
            case InfoType.Level:
                resourceText.text = string.Format("·¹º§.{0:F0}", GameManager.instance.level);
                break;
            case InfoType.Kill:
                resourceText.text = string.Format("{0:F0}", GameManager.instance.kill);
                break;
            case InfoType.Time:
                float remainTime = GameManager.instance.maxGameTime - GameManager.instance.gameTime;
                int min = Mathf.FloorToInt(remainTime / 60);
                int sec = Mathf.FloorToInt(remainTime % 60);
                resourceText.text = string.Format("{0:D2}:{1:D2}", min, sec);
                break;
            case InfoType.Health:
                float curHelath = GameManager.instance.health;
                float maxHealth = GameManager.instance.maxHealth;
                mySlider.value = curHelath / maxHealth;
                break;
        }
    }
}
