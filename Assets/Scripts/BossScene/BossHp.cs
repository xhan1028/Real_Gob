using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHp : MonoBehaviour
{
    [SerializeField]
    private Slider hpbar;

    private float maxHp = 100;
    private float curHp = 100;

    float imsi;

    public GameObject bossObject;

    void Start()
    {
        hpbar.value = (float)curHp / (float)maxHp;
        imsi = (float)curHp / (float)maxHp;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(curHp > 0)
            {
                curHp -= 10;
            }
            else
            {
                curHp = 0;
            }
            imsi = (float)curHp / (float)maxHp;
        }

        HandleHp();

        if (curHp == 0)
        {
            Destroy(bossObject);
        }
    }

    private void HandleHp()
    {
        hpbar.value = Mathf.Lerp(hpbar.value, imsi, Time.deltaTime * 10);
    }
}
