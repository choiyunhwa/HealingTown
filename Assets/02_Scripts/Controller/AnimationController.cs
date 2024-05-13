using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    protected Controller controller;
    protected Animator animator;

    protected virtual void OnEnable()
    {
        controller = GetComponent<Controller>();
        animator = GetComponentInChildren<Animator>();
    }

}
