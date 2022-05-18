using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.DownArrow)
            || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            animator.SetBool("IsWalking", true);
        }
        else if (Input.GetKey("space"))
        {
            animator.SetBool("IsThrowing", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);

            animator.SetBool("IsThrowing", false);
        }
    }
}
