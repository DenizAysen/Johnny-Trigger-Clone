using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject levelCompletePanel;
    [SerializeField] private GameObject gameOverPanel;
    private void OnEnable()
    {
        GameManager.onGameStateChanged += OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState state)
    {
        switch(state)
        {
            case GameState.PreGame:
                menuPanel.SetActive(true);
                gamePanel.SetActive(false);
                levelCompletePanel.SetActive(false);
                gameOverPanel.SetActive(false);
                break;

            case GameState.Game:
                menuPanel.SetActive(false);
                gamePanel.SetActive(true);
                break;

            case GameState.LevelComplete:
                gamePanel.SetActive(false);
                levelCompletePanel.SetActive(true);
                break;

            case GameState.GameOver:
                gamePanel.SetActive(false);
                gameOverPanel.SetActive(true);
                break;          
        }
    }
    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= OnGameStateChanged;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayButton()
    {
        GameManager.Instance.SetGameState(GameState.Game);        
    }
    public void RetryButton() => GameManager.Instance.Retry();
    public void NextButton() => GameManager.Instance.NextLevel();
}
