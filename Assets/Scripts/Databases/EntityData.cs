﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TO Databases/Entity")]
public class EntityData : ScriptableObject
{
    [SerializeField] private int _hp = 10;

    public int Hp { get => _hp; }
}
