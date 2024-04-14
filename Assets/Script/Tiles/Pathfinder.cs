using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] private Vector2Int _startCoordinate;
    [SerializeField] private Vector2Int _destinationCoordinate;
    
    private Node _currentSearchNode;
    private Node _startNode;
    private Node _destinationNode;

    private Queue<Node> _frontier = new Queue<Node>();
    private Dictionary<Vector2Int, Node> _reached = new Dictionary<Vector2Int, Node>();

    private Vector2Int[] _directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    private GridManager _gridManager;
    private Dictionary<Vector2Int, Node> _grid = new Dictionary<Vector2Int, Node>();

    private void Awake()
    {
        _gridManager = FindObjectOfType<GridManager>();
        if (_gridManager != null)
        {
            _grid = _gridManager.dictGrid;
        }
        _startNode = new Node(_startCoordinate, true);
        _destinationNode = new Node(_destinationCoordinate, true); 

    }

    private void Start()
    {
        BFS();
    }

    private void ExploreNeighbors()
    {
        List<Node> neighbors = new List<Node>();

        foreach (Vector2Int direction in _directions)
        {
            Vector2Int neighborCoords = _currentSearchNode.coordinate + direction;

            if (_grid.ContainsKey(neighborCoords))
            {
                neighbors.Add(_grid[neighborCoords]);

                ////TODO: Remove after testing
                //_grid[neighborCoords].isExplored = true;
                //_grid[_currentSearchNode.coordinate].isPath = true;
            }
        }

        foreach (Node neighbor in neighbors)
        {
            if (!_reached.ContainsKey(neighbor.coordinate) && neighbor.isWalkable)
            {
                _reached.Add(neighbor.coordinate, neighbor);
                _frontier.Enqueue(neighbor);
            }
        }
    }

    private void BFS()
    {
        bool isRunning = true;
        _frontier.Enqueue(_startNode);
        _reached.Add(_startCoordinate, _startNode);

        while (_frontier.Count > 0 && isRunning)
        {
            _currentSearchNode = _frontier.Dequeue();
            _currentSearchNode.isExplored = true;
            ExploreNeighbors();

            Debug.Log(_currentSearchNode.coordinate);
            if (_currentSearchNode.coordinate == _destinationNode.coordinate)
            {
                isRunning = false;
            }

        }
    }

}
