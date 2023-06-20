using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Option : MonoBehaviour
{
    public Animator animator;

    public int health = 500;
  //  int currentHealth;

    //void Start()
    //{
        //currentHealth = maxHealth;
   // }

    public void TakeDamage(int damage)
    {
        health -= damage;

        animator.SetTrigger("Hurt");

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("»ç¸Á");

        animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
