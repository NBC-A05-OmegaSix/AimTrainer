using UnityEngine;

public class PlayerRunState : PlayerGroundedState
{
    private float footstepInterval = 0.15f;
    private float nextFootstepTime;
    public PlayerRunState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }
    public override void Update()
    {
        base.Update();
        if (Time.time >= nextFootstepTime)
        {
            AudioManager.Instance.PlaySFX(SoundEffects.Sfx.RunLeftFoot);
            nextFootstepTime = Time.time + footstepInterval;
        }
    }

    public override void Enter()
    {
        AudioManager.Instance.PlaySFX(SoundEffects.Sfx.RunLeftFoot);
        nextFootstepTime = Time.time + footstepInterval;
        stateMachine.MovementSpeedModifier = groundData.RunSpeedModifier;
        base.Enter();
    }


    public override void Exit()
    {
        base.Exit();
    }
}