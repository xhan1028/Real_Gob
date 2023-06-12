using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_Start : MonoBehaviour
{
    public void Start_Boss()
    {
        SceneManager.LoadScene("Boss");
    }
}
