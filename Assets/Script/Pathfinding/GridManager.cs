using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _gridSize;

    private Dictionary<Vector2Int, Node> _dictGrid = new Dictionary<Vector2Int, Node>();

    private void Awake()
    {
        CreateGrid();
    }

    public Node GetNode(Vector2Int coordinate)
    {
        if (_dictGrid.ContainsKey(coordinate))
        {
            return _dictGrid[coordinate];
        }

        return null;
    }


    private void CreateGrid()
    {
        for (int x = 0; x < _gridSize; x++)
        {
            for (int y = 0; y < _gridSize; y++)
            {
                Vector2Int coordinate = new Vector2Int(x, y);
                _dictGrid.Add(coordinate, new Node(coordinate, true));
                Debug.Log(_dictGrid[coordinate].coordiante +  " = " + _dictGrid[coordinate].isWalkable);
            }
        }
    }
}
