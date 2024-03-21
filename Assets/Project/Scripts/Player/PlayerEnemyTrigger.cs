using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyTrigger : MonoBehaviour
{
    private bool _checkForShootingEnemies;
    //private Vector3 _rayOrigin, _rayDirection, _worldSpaceSecondPoint;
    //private float _maxDistance;
    private List<Enemy> currentEnemies = new List<Enemy>();
    List<Enemy> enemiesToRemove = new List<Enemy>();

    [SerializeField] private LayerMask enemyLayerMask;
    [SerializeField] private LineRenderer shootingLine;

    private void OnEnable()
    {
        PlayerMovement.onEnteredWarzone += OnEnteredWarzone;
        PlayerMovement.onExitedWarzone += OnExitedWarzone;
    }
    private void OnEnteredWarzone()
    {
        _checkForShootingEnemies = true;
    }
    private void OnExitedWarzone()
    {
        _checkForShootingEnemies = false;
    }
    private void OnDestroy()
    {
        PlayerMovement.onEnteredWarzone -= OnEnteredWarzone;
        PlayerMovement.onExitedWarzone -= OnExitedWarzone;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_checkForShootingEnemies)
            CheckForShootingEnemies();
    }

    private void CheckForShootingEnemies()
    {
        Vector3 _rayOrigin = shootingLine.transform.TransformPoint(shootingLine.GetPosition(0));
        Vector3 _worldSpaceSecondPoint = shootingLine.transform.TransformPoint(shootingLine.GetPosition(1));

        Vector3 _rayDirection = (_worldSpaceSecondPoint - _rayOrigin).normalized;
        float _maxDistance = Vector3.Distance(_rayOrigin, _worldSpaceSecondPoint);

        RaycastHit[] hits = Physics.RaycastAll(_rayOrigin, _rayDirection, _maxDistance, enemyLayerMask);

        for (int i = 0; i < hits.Length; i++)
        {
            Enemy currentEnemy = hits[i].collider.GetComponent<Enemy>();
            if (!currentEnemies.Contains(currentEnemy))
            {
                currentEnemies.Add(currentEnemy);
            }
            Debug.Log(hits[i].collider.name);
        }

        foreach (Enemy enemy in currentEnemies)
        {
            bool enemyFound = false;

            for (int i = 0; i< hits.Length; i++)
            {
                if (hits[i].collider.GetComponent<Enemy>() == enemy)
                {
                    enemyFound = true;
                    break;
                }
            }

            if (!enemyFound)
            {
                enemy.ShootAtPlayer();
                enemiesToRemove.Add(enemy);
            }
        }

        foreach(Enemy enemy in enemiesToRemove)
            currentEnemies.Remove(enemy);
    }
}
