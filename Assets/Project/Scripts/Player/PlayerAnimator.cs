using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string _run = "Run";
    private const string _idle = "Idle";

    [SerializeField] private Animator animator;
    public void PlayRunAnimation() => Play(_run);
    public void PlayIdleAnimation() => Play(_idle);
    public void Play(string animationName) => animator.Play(animationName);
    public void Play(string animationName, float animatorSpeed)
    {
        animator.speed = animatorSpeed;
        Play(animationName);
    }
}
