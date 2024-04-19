using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Tower _towerPrefab;

    [SerializeField] private bool _isPlacable = true;
    public bool IsPlacable { get { return _isPlacable; } }

    private GridManager gridManager;
    private Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
    }

    void Start()
    {
        if (gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if (!_isPlacable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }


    private void OnMouseDown()
    {
        if (_isPlacable)
        {
            bool isPlaced = _towerPrefab.CreateTower(_towerPrefab, this.transform.position);
            _isPlacable = !isPlaced;
        }
    }
}
