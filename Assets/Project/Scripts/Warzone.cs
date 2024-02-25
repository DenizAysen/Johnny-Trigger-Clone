using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warzone : MonoBehaviour
{
    [SerializeField] private SplineComputer newPlayerSpline;
    [SerializeField] private float duration;
    [SerializeField] private float animatorSpeed;
    [SerializeField] private string animationToPlay;
    public SplineComputer GetPlayerSpline() => newPlayerSpline;
    public float GetDuration() => duration;
    public float GetAnimatorSpeed() => animatorSpeed;
    public string GetAnimationToPlay() => animationToPlay;
}
