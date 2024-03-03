using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private EnemyBullet bulletPrefab;
    [SerializeField] private Transform bulletsParent;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float bulletSpeed;

    private bool _hasShot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TryShooting()
    {
        if (_hasShot)
            return;

        _hasShot = true;

        Invoke("Shoot", .1f);
    }
    private void Shoot()
    {
        Vector3 velocity = bulletSpeed * bulletSpawnPoint.right;

        EnemyBullet bullet = Instantiate(bulletPrefab,bulletSpawnPoint.position,Quaternion.identity,bulletsParent);
        bullet.Configure(velocity);
    }
}
