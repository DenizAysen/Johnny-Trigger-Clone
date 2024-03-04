using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameState _gameState;

    public static Action<GameState> onGameStateChanged;

    #region Singleton
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    } 
    #endregion
    void Start()
    {
        SetGameState(GameState.PreGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetGameState(GameState gameState)
    {
        _gameState = gameState;
        onGameStateChanged?.Invoke(_gameState);
    }
    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
    public bool IsGameState() => _gameState == GameState.Game;
    public void NextLevel()
    {
        SceneManager.LoadScene(0);
    }
}
