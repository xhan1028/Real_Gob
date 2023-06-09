using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("# Game Control")]
    public float gameTime;
    public float maxGameTime = 2 * 10f;
    [Header("# Player Info")]
    public int level;
    public int health;
    public int maxHealth = 100;
    public int kill;
    public int exp;
    public int[] nextExp = { 10, 30, 50, 100, 150, 250, 400, 550, 750, 1000};
    [Header("# Game Object")]
    public PoolManager pool;
    public Chr_Move chr_move;
       
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }

    public void GetExp()
    {
         exp++;

         if (exp == nextExp[level])
         {
              level++;
              exp = 0;
              
         }
    }
}
