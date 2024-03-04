using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GameObject shootingLine;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform bulletSpawnPosition;
    [SerializeField] private Transform bulletsParent;
    [SerializeField] private float bulletSpeed;

    private bool _canShoot;
    private void OnEnable()
    {
        PlayerMovement.onEnteredWarzone += OnEnteredWarzone;
        PlayerMovement.onExitedWarzone += OnExitedWarzone;
        PlayerMovement.onDied += OnDied;
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
    private void OnDied()
    {
        SetShootingLineVisibility(false);
        _canShoot= false;
    }
    private void OnDestroy()
    {
        PlayerMovement.onEnteredWarzone -= OnEnteredWarzone;
        PlayerMovement.onExitedWarzone -= OnExitedWarzone;
        PlayerMovement.onDied += OnDied;
    }
    void Start()
    {
        SetShootingLineVisibility(false);
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
        Vector3 direction = bulletSpawnPosition.right;
        direction.z = 0f;

        Bullet bulletInstance = Instantiate(bulletPrefab,bulletSpawnPosition.position,Quaternion.identity,bulletsParent);

        bulletInstance.Configure(direction * bulletSpeed);

    }

    private void SetShootingLineVisibility(bool visibility)
    {
        shootingLine.SetActive(visibility);
    }
}
