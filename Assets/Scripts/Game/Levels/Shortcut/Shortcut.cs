﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shortcut : Entity
{
    #region Fields
    public static readonly float TRANSITION_DURATION = 0.1f;

    [Header("Shortcut")]
    [SerializeField] private GameObject _window;
    [SerializeField] private bool _closeOnStart = true;

    private bool _isWindowOpen = true;

    // cache variables
    private Vector3 _deltaTargetPosition;
    private Image[] _images;
    #endregion

    #region Methods
    void Start()
    {
        _deltaTargetPosition = _window.transform.position - transform.position;
        _images = transform.GetComponentsInChildren<Image>();

        if (_closeOnStart)
        {
            _isWindowOpen = false;

            _window.transform.localScale = Vector3.zero;
            _window.transform.position = transform.position;
        }
    }

    public override void GetDamage(int damage, Entity attacker)
    {
        SwitchWindowState();

        OnDamage?.Invoke(this, damage);
    }

    private void SwitchWindowState()
    {
        _isWindowOpen = !_isWindowOpen;

        new Timer(this, TRANSITION_DURATION, (float t) =>
        {
            if (!_isWindowOpen)
            {
                t = -1 * t + 1; // reverse t parameter
            }

            _window.transform.localScale = Vector3.one * t;
            _window.transform.position = transform.position + _deltaTargetPosition * t;

            for (int i = 0; i < _images.Length; i++)
            {
                _images[i].color.SetAlpha(t);
            }
        });
    }

    public void OpenWindow()
    {
        if (_isWindowOpen)
            return;

        SwitchWindowState();
    }
    #endregion
}
