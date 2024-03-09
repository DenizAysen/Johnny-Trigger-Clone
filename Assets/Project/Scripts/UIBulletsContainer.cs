using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBulletsContainer : MonoBehaviour
{
    public static UIBulletsContainer Instance;

    [SerializeField] private Transform bulletsParent;
    [SerializeField] private Color activeColor;
    [SerializeField] private Color inactiveColor;

    private int _bulletsShot;
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void OnEnable()
    {
        PlayerShooter.onShot += OnShot;
        PlayerMovement.onEnteredWarzone += OnEnteredWarzone;
        PlayerMovement.onExitedWarzone += OnExitedWarzone;
    }
    private void OnShot()
    {
        _bulletsShot++;

       _bulletsShot = Math.Min(_bulletsShot,bulletsParent.childCount);

        bulletsParent.GetChild(_bulletsShot - 1).GetComponent<Image>().color = inactiveColor;
    }
    private void OnEnteredWarzone()
    {
        bulletsParent.gameObject.SetActive(true);
    }
    private void OnExitedWarzone()
    {
        bulletsParent.gameObject.SetActive(false);

        Reload();
    }
    private void OnDestroy()
    {
        PlayerShooter.onShot -= OnShot;
        PlayerMovement.onEnteredWarzone -= OnEnteredWarzone;
        PlayerMovement.onExitedWarzone -= OnExitedWarzone;
    }
    // Start is called before the first frame update
    void Start()
    {
        bulletsParent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool CanShoot() => _bulletsShot < bulletsParent.childCount;
    private void Reload()
    {
        _bulletsShot = 0;

        for (int i = 0; i < bulletsParent.childCount; i++)
        {
            bulletsParent.GetChild(i).GetComponent<Image>().color = activeColor;
        }
    }
}
