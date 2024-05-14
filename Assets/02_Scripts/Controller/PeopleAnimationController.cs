using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleAnimationController : AnimationController
{
    private SpriteRenderer playerRanderer;

    public static readonly int isWalking = Animator.StringToHash("isWalk");

    private readonly float magnituteThreshold = 0.5f;

    public virtual void Start()
    {
        controller.OnMoveEvent += Move;
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        playerRanderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Move(Vector2 vector)
    {
        animator.SetBool(isWalking, vector.magnitude > magnituteThreshold);

        playerRanderer.flipX = vector.x < 0;

        animator.SetFloat("xDir", Mathf.Abs(vector.x));
        animator.SetFloat("yDir", vector.y);
    }    
}
