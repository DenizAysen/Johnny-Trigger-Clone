using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyState _enemyState;

    [SerializeField] private CharacterRagdoll characterRagdoll;
    void Start()
    {
        _enemyState = EnemyState.Alive;
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
}
