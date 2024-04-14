using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{ //Todo: change this class to singleton
    [SerializeField] private Vector2Int _gridSize;

    private Dictionary<Vector2Int, Node> _dictGrid = new Dictionary<Vector2Int, Node>();

    public Dictionary<Vector2Int, Node> dictGrid { get { return _dictGrid; } }

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

    public void BlockedNode(Vector2Int coordinate)
    {
        if (_dictGrid.ContainsKey(coordinate))
        {
            _dictGrid[coordinate].isWalkable = false;
        }
    }

    public Vector2Int GetCoordinateFromPosition(Vector3 position)
    {
        Vector2Int coordinate = new Vector2Int();

        coordinate.x = Mathf.RoundToInt(position.x / 10);
        coordinate.y = Mathf.RoundToInt(position.z / 10);

        return coordinate;
    }


    private void CreateGrid()
    {
        for (int x = 0 + 7; x < _gridSize.x + 7; x++)
        {
            for (int y = 0 + 2; y < _gridSize.y + 2; y++)
            {
                Vector2Int coordinate = new Vector2Int(x, y);
                _dictGrid.Add(coordinate, new Node(coordinate, true));
                //Debug.Log(_dictGrid[coordinate].coordiante +  " = " + _dictGrid[coordinate].isWalkable);
            }
        }
    }
}
