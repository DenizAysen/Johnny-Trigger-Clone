using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _velocity;

    [SerializeField] private LayerMask enemyLayerMask;
    [SerializeField] private float detectionRadius;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        CheckForEnemies();
    }
    private void Move()
    {
        transform.position += _velocity * Time.deltaTime;
    }
    public void CheckForEnemies()
    {
        Collider[] detectedEnemies = Physics.OverlapSphere(transform.position, detectionRadius,enemyLayerMask);

        foreach (Collider enemyCol in detectedEnemies)
            enemyCol.GetComponent<Enemy>().TakeDamage();
    }
    public void Configure(Vector3 velocity)
    {
        _velocity = velocity;
    }
}
