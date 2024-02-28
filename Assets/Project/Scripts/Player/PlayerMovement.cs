using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using System;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float slowMoScale;
    [SerializeField] private PlayerAnimator playerAnimator;
    [SerializeField] private PlayerIK playerIK;

    private State _state;
    private Warzone _currentWarzone;
    private float _warzoneTimer;
    private float _splinePercent;

    private const string _run = "Run";
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
    public void OnEnteredWarzone(Warzone warzone)
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
    }
}
