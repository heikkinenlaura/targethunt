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
        if (Input.GetKey("w"))

        {
            animator.SetBool("IsWalking", true);
        }

        if (!Input.GetKey("w"))
        {
            animator.SetBool("IsWalking", false);
        }

    }
}
