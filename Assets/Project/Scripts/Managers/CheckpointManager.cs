using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Vector3 _lastCheckpointPosition;

    public static CheckpointManager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }
    private void OnEnable()
    {
        Checkpoint.onInteracted += OnInteracted;
        GameManager.onGameStateChanged += OnGameStateChanged;
    }
    private void OnInteracted(Checkpoint checkpoint)
    {
        _lastCheckpointPosition = checkpoint.GetPosition();
    }
    private void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.LevelComplete:
                _lastCheckpointPosition = Vector3.zero;
                break;
        }
    }   
    private void OnDestroy()
    {
        Checkpoint.onInteracted -= OnInteracted;
        GameManager.onGameStateChanged -= OnGameStateChanged;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector3 GetCheckpointPosition() => _lastCheckpointPosition;
}
