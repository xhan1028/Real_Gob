using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway_Jump : MonoBehaviour
{
    bool isJump = false;
    bool isTop = false;
    public float jumpSpeed = 0;
    public float jumpHeight = 0;

    Vector2 startPosition;
    Animator animator;

    void Start()
    {
        startPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Run",true);
        if(Input.GetMouseButtonDown(0))
        {
            isJump = true;
        }
        else if(transform.position.y <= startPosition.y)
        {
            isJump = false;
            isTop = false;
            transform.position = startPosition;
        }

        if (isJump)
        {
            if(transform.position.y <= jumpHeight - 0.1f && !isTop)
            {
                transform.position = Vector2.Lerp(transform.position,new Vector2(transform.position.x,jumpHeight),jumpSpeed * Time.deltaTime);
            }
            else
            {
                isTop = true;
            }
            if (transform.position.y > startPosition.y && isTop)
            {
                transform.position = Vector2.MoveTowards(transform.position,startPosition,jumpSpeed * Time.deltaTime);
            }
        }
    }
}