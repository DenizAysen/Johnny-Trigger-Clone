using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GameObject shootingLine;
    private void OnEnable()
    {
        PlayerMovement.onEnteredWarzone += OnEnteredWarzone;
        PlayerMovement.onExitedWarzone += OnExitedWarzone;
    }
    private void OnEnteredWarzone()
    {
        SetShootingLineVisibility(true);
    }
    private void OnExitedWarzone()
    {
        SetShootingLineVisibility(false);
    }

    void Start()
    {
        SetShootingLineVisibility(false);
    }
    private void OnDestroy()
    {
        PlayerMovement.onEnteredWarzone -= OnEnteredWarzone;
        PlayerMovement.onExitedWarzone -= OnExitedWarzone;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void SetShootingLineVisibility(bool visibility)
    {
        shootingLine.SetActive(visibility);
    }
}
