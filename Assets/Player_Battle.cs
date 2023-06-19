using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Battle : MonoBehaviour
{

	public Animator animator;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Attack_Player();
		}
	}

	void Attack_Player()
	{
		animator.SetTrigger("Attack_Player");
	}
}
