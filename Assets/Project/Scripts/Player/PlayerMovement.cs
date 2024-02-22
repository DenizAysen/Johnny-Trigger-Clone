using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private PlayerAnimator playerAnimator;

    private State _state;
    void Start()
    {
        Application.targetFrameRate = 60;

        _state = State.Idle;
    }

    // Update is called once per frame
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
}