using UnityEngine;

public class PlayerView
{
    private readonly Animator _animator;
    private readonly SoundManager _soundManager;

    public PlayerView(Animator animator, SoundManager soundManager)
    {
        _animator = animator;
        _soundManager = soundManager;
    }

    public void SetPlayerAnimation(string animationTitle)
    {
        _animator.Play(animationTitle);
    }

    public void SetDeathSound()
    {
        _soundManager.CreateSound(SoundType.HIT_1)
                     .PlayOnce();
    }
}
