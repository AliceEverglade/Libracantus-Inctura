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
    string currentState;
    const string IDLE = "Idle";
    const string WALK = "Walk";

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float dir = Input.GetAxis("Horizontal");
        transform.Translate(transform.right * dir * speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        if (Input.GetButton("Horizontal"))
        {
            ChangeAnimationState(WALK);
        }
        if (!IsAnimtionPlaying(animator, currentState))
        {
            ChangeAnimationState(IDLE);
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

    private void ChangeAnimationState(string newState)
    {
        if (newState == currentState)
        {
            return;
        }

        animator.Play(newState);

        currentState = newState;
    }

    bool IsAnimtionPlaying(Animator animator, string stateName)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(stateName) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
