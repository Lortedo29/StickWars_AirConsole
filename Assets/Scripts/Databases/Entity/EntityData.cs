﻿using System.Collections;
using System.Collections.Generic;
using TF.Utilities.RemoteConfig;
using UnityEngine;

[CreateAssetMenu(menuName = "StickWars/Entity")]
public class EntityData : RemoteConfigScriptableObject
{
    [SerializeField] private int _hp = 10;

    public int Hp { get => _hp; }
}
