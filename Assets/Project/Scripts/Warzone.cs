using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warzone : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField] private SplineComputer newPlayerSpline;
    [SerializeField] private SplineFollower ikSplineFollower;
    [SerializeField] private Transform ikTarget;

    [SerializeField] private float duration;
    [SerializeField] private float animatorSpeed;
    [SerializeField] private string animationToPlay;

    [SerializeField] private Warzone nextWarzone; 
    #endregion
    private void Start()
    {
        ikSplineFollower.followDuration = duration;
    }
    public void StartAnimatingIKtarget()
    {
        ikSplineFollower.follow = true;
    }
    public SplineComputer GetPlayerSpline() => newPlayerSpline;
    public float GetDuration() => duration;
    public float GetAnimatorSpeed() => animatorSpeed;
    public string GetAnimationToPlay() => animationToPlay;
    public Transform GetIKTarget()
    {
        return ikTarget;
    }
    public Warzone GetNextWarzone() => nextWarzone;
}
