using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Vector3 _velocity;

    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float detectionRadius;
    void Start()
    {
        
    }
    void Update()
    {
        Move();

        CheckForPlayer();
    }
    private void Move()
    {
        transform.position += _velocity * Time.deltaTime;
    }
    public void Configure(Vector3 velocity)
    {
        _velocity = velocity;
    }
    public void CheckForPlayer()
    {
        Collider[] detectedPlayer = Physics.OverlapSphere(transform.position, detectionRadius, playerMask);

        foreach (Collider playerCol in detectedPlayer)
            playerCol.GetComponent<PlayerMovement>().TakeDamage();
    }
}
