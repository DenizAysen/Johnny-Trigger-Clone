using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] levels;
    [SerializeField] private bool preventSpawning;

    private int _levelIndex;
    private void Awake()
    {
        LoadData();

        if(!preventSpawning)
            SpawnLevel();
    }
    private void OnEnable()
    {
        GameManager.onGameStateChanged += OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.LevelComplete:
                _levelIndex++;
                SaveData();
                break;

        }
    }
    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= OnGameStateChanged;
    }
    private void LoadData() => _levelIndex = PlayerPrefs.GetInt("Level");
    private void SaveData() => PlayerPrefs.SetInt("Level", _levelIndex);
    private void SpawnLevel()
    {
        if(_levelIndex >= levels.Length)
            _levelIndex = 0;

        GameObject levelInstance = Instantiate(levels[_levelIndex], transform);

        StartCoroutine(EnableLevelCoroutine(levelInstance));
    }
    private IEnumerator EnableLevelCoroutine(GameObject level)
    {
        yield return new WaitForSeconds(Time.deltaTime);

        level.SetActive(true);
    }   
}
