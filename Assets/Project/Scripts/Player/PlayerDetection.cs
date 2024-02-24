using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerDetection : MonoBehaviour
{
    [SerializeField] private float detectionRadius;

    private const string _warzoneEnter = "WarzoneEnter";
    private PlayerMovement _playerMovement;
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        DetectStuff();
    }
    private void DetectStuff()
    {
        Collider[] detectedObjects = Physics.OverlapSphere(transform.position, detectionRadius);

        foreach (Collider col in detectedObjects)
        {
            if (col.CompareTag(_warzoneEnter))
            {
                Debug.Log(col.name);
                OnEnteredWarzone(col);
            }
        }
    }
    private void OnEnteredWarzone(Collider warzoneCollider)
    {
        Warzone warzone = warzoneCollider.GetComponentInParent<Warzone>();
        _playerMovement.OnEnteredWarzone(warzone);
    }
}
