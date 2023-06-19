using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Battles : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 40;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    Boss_Option boss_option;

    void Update()
    {
       if(Time.time >= nextAttackTime)
       {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                 Attack_Player();
                 nextAttackTime = Time.time + 1f / attackRate;
            }
       }
    }

    void Attack_Player()
    {
        animator.SetTrigger("Attack_Player");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D boss_option in hitEnemies)
        {
            boss_option.GetComponent<Boss_Option>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
