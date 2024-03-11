using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] levels;
    void Start()
    {
        GameObject levelInstance = Instantiate(levels[0], transform);

        StartCoroutine(EnableLevelCoroutine(levelInstance));
    }

    private IEnumerator EnableLevelCoroutine(GameObject level)
    {
        yield return new WaitForSeconds(Time.deltaTime);

        level.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
