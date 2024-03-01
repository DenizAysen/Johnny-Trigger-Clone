using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GameObject shootingLine;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform buletSpawnPosition;

    private bool _canShoot;
    private void OnEnable()
    {
        PlayerMovement.onEnteredWarzone += OnEnteredWarzone;
        PlayerMovement.onExitedWarzone += OnExitedWarzone;
    }
    private void OnEnteredWarzone()
    {
        SetShootingLineVisibility(true);
        _canShoot = true;
    }
    private void OnExitedWarzone()
    {
        SetShootingLineVisibility(false);
        _canShoot = false;
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
        if (!_canShoot)
            return;
        ManageShooting();
    }

    private void ManageShooting()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab,buletSpawnPosition.position,Quaternion.identity);
    }

    private void SetShootingLineVisibility(bool visibility)
    {
        shootingLine.SetActive(visibility);
    }
}
