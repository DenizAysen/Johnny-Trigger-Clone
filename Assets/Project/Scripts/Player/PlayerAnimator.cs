using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string _run = "Run";

    [SerializeField] private Animator animator;
    public void PlayRunAnimation() => Play(_run);
    public void Play(string animationName) => animator.Play(animationName);
    public void Play(string animationName, float animatorSpeed)
    {
        animator.speed = animatorSpeed;
        Play(animationName);
    }
}
