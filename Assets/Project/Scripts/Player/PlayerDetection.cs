using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerDetection : MonoBehaviour
{
    [SerializeField] private float detectionRadius;

    private const string _warzoneEnter = "WarzoneEnter";
    private const string _finish = "Finish";
    private PlayerMovement _playerMovement;
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if (!GameManager.Instance.IsGameState())
            return;

        DetectStuff();
    }
    private void DetectStuff()
    {
        Collider[] detectedObjects = Physics.OverlapSphere(transform.position, detectionRadius);

        foreach (Collider col in detectedObjects)
        {
            if (col.CompareTag(_warzoneEnter))
            {
                //Debug.Log(col.name);
                OnEnteredWarzone(col);
            }
            else if (col.CompareTag(_finish))
            {
                HitFinishLine();
            }

            if(col.TryGetComponent(out Checkpoint checkpoint))
            {
                checkpoint.Interact();
            }
        }
    }
    private void OnEnteredWarzone(Collider warzoneCollider)
    {
        Warzone warzone = warzoneCollider.GetComponentInParent<Warzone>();
        _playerMovement.EnterWarzone(warzone);
    }
    private void HitFinishLine()
    {
        _playerMovement.HitFinishLine();
    }
}
