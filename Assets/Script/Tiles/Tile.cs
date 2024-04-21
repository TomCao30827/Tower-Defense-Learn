﻿using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Tower _towerPrefab;

    [SerializeField] private bool _isPlacable = true;
    public bool IsPlacable { get { return _isPlacable; } }

    private GridManager _gridManager;
    private Vector2Int coordinate = new Vector2Int();
    private Pathfinder _pathFinder;

    void Awake()
    {
        _gridManager = FindObjectOfType<GridManager>();
        _pathFinder = FindObjectOfType<Pathfinder>();
    }

    void Start()
    {
        if (_gridManager != null)
        {
            coordinate = _gridManager.GetCoordinatesFromPosition(transform.position);

            if (!_isPlacable)
            {
                _gridManager.BlockNode(coordinate);
            }
        }
    }


    private void OnMouseDown()
    {
        if (_gridManager.GetNode(coordinate).isWalkable && !_pathFinder.WillBlockPath(coordinate))
        {
            bool isSuccussful = _towerPrefab.CreateTower(_towerPrefab, transform.position);
            Debug.Log(isSuccussful);
            if (isSuccussful)
            {
                _gridManager.BlockNode(coordinate);
                _pathFinder.NotifyReceivers();
            }

        }
    }
}
