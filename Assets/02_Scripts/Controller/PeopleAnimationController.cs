using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleAnimationController : AnimationController
{
    public static readonly int isWalking = Animator.StringToHash("isWalk");

    private readonly float magnituteThreshold = 0.5f;

    public virtual void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 vector)
    {
        animator.SetBool(isWalking, vector.magnitude > magnituteThreshold);

        animator.SetFloat("xDir", vector.x);
        animator.SetFloat("yDir", vector.y);
    }    
}
