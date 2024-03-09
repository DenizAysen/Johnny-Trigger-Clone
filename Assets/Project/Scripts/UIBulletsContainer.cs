using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBulletsContainer : MonoBehaviour
{
    [SerializeField] private Transform bulletsParent;
    [SerializeField] private Color activeColor;
    [SerializeField] private Color inactiveColor;

    private int _bulletsShot;
    private void OnEnable()
    {
        PlayerShooter.onShot += OnShot;
    }

    private void OnShot()
    {
        _bulletsShot++;

        if(_bulletsShot > bulletsParent.childCount)
            _bulletsShot = bulletsParent.childCount;

        bulletsParent.GetChild(_bulletsShot - 1).GetComponent<Image>().color = inactiveColor;
    }
    private void OnDestroy()
    {
        PlayerShooter.onShot -= OnShot;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
