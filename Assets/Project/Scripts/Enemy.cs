using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyState _enemyState;

    [SerializeField] private CharacterRagdoll characterRagdoll;
    [SerializeField] private CharacterIK characterIK;
    private PlayerMovement _playerMovement;
    void Start()
    {
        _enemyState = EnemyState.Alive;

        _playerMovement = FindObjectOfType<PlayerMovement>();
        characterIK.ConfigureIK(_playerMovement.GetEnemyTarget());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage()
    {
        if (_enemyState == EnemyState.Dead)
            return;

        Die();
    }

    private void Die()
    {
        _enemyState = EnemyState.Dead;

        characterRagdoll.Ragdollify();
    }
    public void ShootAtPlayer()
    {
        Debug.Log("Shooting at player");
    }
}
