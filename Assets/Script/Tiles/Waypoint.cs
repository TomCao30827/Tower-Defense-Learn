﻿using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Tower _towerPrefab;

    [SerializeField] private bool _isPlacable = true;
    public bool IsPlacable { get { return _isPlacable; } }


    private void OnMouseDown()
    {
        if (_isPlacable)
        {
            bool isPlaced = _towerPrefab.CreateTower(_towerPrefab, this.transform.position);
            _isPlacable = !isPlaced;
        }
    }
}
