using UnityEngine;

public class TopDownAnimationController : PeopleAnimationController
{
    public static readonly int isRunning = Animator.StringToHash("isRun");
    public static readonly int isJumping = Animator.StringToHash("isJump");

    public override void Start()
    {
        base.Start();
        
        controller.OnJumpEvent += Jump;
    }


    private void Run()
    {

    }

    private void Jump()
    {
        
    }
}
