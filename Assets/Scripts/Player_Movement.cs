using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;
	public float jumpPower;
	
	float horizontalMove = 0f;
	private bool jump = false;
	private Rigidbody2D rigid;

	private void Awake()
	{
		rigid = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetKeyDown(KeyCode.W))
		{
			if (!jump)
			{
				jump = true;
				rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
			}
		}
	}

	void FixedUpdate()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
	//	jump = false;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name.Equals("Area"))
		{
			jump = false;
		}
	}
}
