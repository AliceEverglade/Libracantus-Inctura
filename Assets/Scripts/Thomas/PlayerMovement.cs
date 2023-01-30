using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement player
    [Header("Speed")]
    public float speed = 10;

    //Animation player
    Animator animator;
    Rigidbody2D rb;
    [SerializeField] private animationStates currentState = animationStates.Idle;
    public animationStates CurrentState
    {
        get 
        { 
            return currentState; 
        }
        private set
        {
            if(currentState != value)
            {
                animator.Play(value.ToString());
                currentState = value;
            }
        }
    }

    public enum animationStates
    {
        Idle,
        Run
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float dir = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dir * speed, rb.velocity.y);

        if (Input.GetButton("Horizontal"))
        {
            CurrentState = animationStates.Run;
        }

        if (!Input.GetButton("Horizontal"))
        {
            CurrentState = animationStates.Idle;
        }

        if (dir < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (dir > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}