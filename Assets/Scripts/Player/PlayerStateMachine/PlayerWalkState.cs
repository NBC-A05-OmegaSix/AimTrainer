using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalkState : PlayerGroundedState
{
    private float footstepInterval = 0.7f;
    private float nextFootstepTime;
    public PlayerWalkState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Update()
    {
        base.Update();
        if(Time.time >= nextFootstepTime)
        {
            AudioManager.Instance.PlaySFX(SoundEffects.Sfx.WalkLeftFoot);
            nextFootstepTime = Time.time + footstepInterval;
        }
    }

    public override void Enter()
    {
        AudioManager.Instance.PlaySFX(SoundEffects.Sfx.WalkLeftFoot);
        nextFootstepTime = Time.time + footstepInterval;
        stateMachine.MovementSpeedModifier = groundData.WalkSpeedModifier;
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    protected override void OnRunStarted(InputAction.CallbackContext context)
    {
        base.OnRunStarted(context);
        stateMachine.ChangeState(stateMachine.RunState);
    }
}
