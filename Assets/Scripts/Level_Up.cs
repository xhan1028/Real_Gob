using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Up : MonoBehaviour
{
    RectTransform rect;
    Items[] zangbi;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
        zangbi = GetComponentsInChildren<Items>(true);
    }

    public void Show()
    {
        NewSkill();
        rect.localScale = Vector3.one;
        GameManager.instance.Stop();
    }

    public void Hide()
    {
        rect.localScale = Vector3.zero;
        GameManager.instance.Resume();
    }

    public void Choice(int index)
   {
       zangbi[index].OnClick();
   }

   void NewSkill()
   {
          foreach (Items item in zangbi)
          {
                item.gameObject.SetActive(false);
          }

          int[] ran = new int[3];
          while (true)
          {
                ran[0] = Random.Range(0, zangbi.Length);
                ran[1] = Random.Range(0, zangbi.Length);
                ran[2] = Random.Range(0, zangbi.Length);

                if (ran[0] != ran[1] && ran[1] != ran[2] && ran[0] != ran[2])
                    break;
          }

          for (int index = 0; index < ran.Length; index++)
          {
                Items randomItem = zangbi[ran[index]];

                if (randomItem.level == randomItem.data.damages.Length)
                {
                    zangbi[4].gameObject.SetActive(true);
                }
                else
                {
                randomItem.gameObject.SetActive(true);
                }
          }
   }
}