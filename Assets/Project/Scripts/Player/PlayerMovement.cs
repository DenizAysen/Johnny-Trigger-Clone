using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using System;
public class PlayerMovement : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float slowMoScale;
    [SerializeField] private PlayerAnimator playerAnimator;
    [SerializeField] private CharacterIK playerIK;
    [SerializeField] private CharacterRagdoll characterRagdoll;
    [SerializeField] private Transform enemyTarget;
    #endregion

    #region Privates
    private State _state;
    private Warzone _currentWarzone;
    private float _warzoneTimer;
    private float _splinePercent;
    private const string _run = "Run";
    #endregion

    #region Actions
    public static Action onEnteredWarzone;
    public static Action onExitedWarzone;
    public static Action onDied;
    #endregion
    void Start()
    {
        Application.targetFrameRate = 60;

        _state = State.Idle;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartRunning();
        }
        ManageState();
    }
    private void ManageState()
    {
        switch (_state)
        {
            case State.Idle:
                break;

            case State.Run:
                Move();
                break;

            case State.Warzone:
                ManageWarzoneState();
                break;
        }
    }
    private void StartRunning()
    {
        _state = State.Run;
        playerAnimator.PlayRunAnimation();
    }
    private void Move()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }
    public void EnterWarzone(Warzone warzone)
    {
        if (_currentWarzone != null)
            return;
        Debug.Log("Entered Warzone");
        _state = State.Warzone;

        _currentWarzone = warzone;

        _currentWarzone.StartAnimatingIKtarget();

        _warzoneTimer = 0;
        _splinePercent = 0;

        playerAnimator.Play(_currentWarzone.GetAnimationToPlay(),_currentWarzone.GetAnimatorSpeed());

        playerIK.ConfigureIK(_currentWarzone.GetIKTarget());

        Time.timeScale = slowMoScale;
        Time.fixedDeltaTime = slowMoScale / 50;

        onEnteredWarzone?.Invoke();
    }
    private void ManageWarzoneState()
    {
        _warzoneTimer += Time.deltaTime;

        _splinePercent = _warzoneTimer / _currentWarzone.GetDuration();
        _splinePercent = Mathf.Clamp(_splinePercent, 0f, 1f);

        transform.position = _currentWarzone.GetPlayerSpline().EvaluatePosition(_splinePercent);

        if (_splinePercent >= 1f)
            ExitWarzone();
    }
    private void ExitWarzone()
    {
        _state = State.Run;
        _currentWarzone = null;
        playerAnimator.Play(_run, 1f);
        playerIK.DisableIK();
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 1f / 50f;
        onExitedWarzone?.Invoke();
    }
    public Transform GetEnemyTarget() => enemyTarget;
    public void TakeDamage() 
    {
        _state = State.Dead;

        characterRagdoll.Ragdollify();
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 1f / 50f;
        onDied?.Invoke();
    }
}
