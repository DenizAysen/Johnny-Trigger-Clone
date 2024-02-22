using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string _run = "Run";

    [SerializeField] private Animator animator;
    public void PlayRunAnimation()
    {
        animator.Play(_run);
    }
}
