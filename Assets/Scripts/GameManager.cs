using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("# Game Control")]
    public float gameTime;
    public float maxGameTime = 2 * 10f;
    public bool isLive;
    [Header("# Player Info")]
    public int level;
    public float health;
    public float maxHealth = 100;
    public int kill;
    public int exp;
    public int[] nextExp = { 10, 20, 40, 65, 100, 130, 170, 215, 260, 333};
    [Header("# Game Object")]
    public PoolManager pool;
    public Chr_Move chr_move;
    public Level_Up stateUp;
    public Result ResultGame;
    public GameObject Cleaner;
       
    void Awake()
    {
        instance = this;
    }

    public void GameStart()
    {
        health = maxHealth;
        stateUp.Choice(0);
        isLive = true;
    }

    void Update()
    {
       // if (!isLive)
         //   return;

        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
            GameWin();
        }
    }

    public void GetExp()
    {
      //  if (!isLive)
          //  return;

         exp++;

         if (exp == nextExp[Mathf.Min(level, nextExp.Length-1)])
         {
              level++;
              exp = 0;
              stateUp.Show();
         }
    }

    public void Stop()
    {
       isLive = false;
       Time.timeScale = 0;
    }

    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        StartCoroutine(GameOverOption());
    }

    IEnumerator GameOverOption()
    {
        isLive = false;

        yield return new WaitForSeconds(0.5f);

        ResultGame.gameObject.SetActive(true);
        ResultGame.Lose();
        Stop();
    }

    public void GameWin()
    {
        StartCoroutine(GameWinOption());
    }

    IEnumerator GameWinOption()
    {
        isLive = false;
        Cleaner.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        ResultGame.gameObject.SetActive(true);
        ResultGame.Win();
        Stop();
    }

    public void ReStart()
    {
        SceneManager.LoadScene("Slayer_1");
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
}
