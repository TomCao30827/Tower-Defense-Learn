using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] private Vector2Int _startCoordinate;
    [SerializeField] private Vector2Int _destinationCoordinate;

    public Vector2Int StartCoordinate { get { return _startCoordinate; } }
    public Vector2Int DestinationCoorinate { get { return _destinationCoordinate; } }
    
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
            _startNode = _grid[_startCoordinate];
            _destinationNode = _grid[_destinationCoordinate];
            _startNode.isWalkable = true;
            _destinationNode.isWalkable = true;
        }
    }

    private void Start()
    {
        GetNewPath();
    }

    public List<Node> GetNewPath()
    {
        _gridManager.ResetNode();
        BFS();
        return BuildPath();
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

            }
        }

        foreach (Node neighbor in neighbors)
        {
            if (!_reached.ContainsKey(neighbor.coordinate) && neighbor.isWalkable)
            {
                neighbor.connectedTo = _currentSearchNode;
                _reached.Add(neighbor.coordinate, neighbor);
                _frontier.Enqueue(neighbor);
            }
        }
    }

    private void BFS()
    {
        _frontier.Clear();
        _reached.Clear();

        bool isRunning = true;
        _frontier.Enqueue(_startNode);
        _reached.Add(_startCoordinate, _startNode);

        while (_frontier.Count > 0 && isRunning)
        {
            _currentSearchNode = _frontier.Dequeue();
            _currentSearchNode.isExplored = true;
            ExploreNeighbors();

            if (_currentSearchNode.coordinate == _destinationNode.coordinate)
            {
                isRunning = false;
            }

        }
    }

    private List<Node> BuildPath()
    {
        List<Node> path = new List<Node>();
        Node currentNode = _destinationNode;
        
        path.Add(currentNode);
        currentNode.isPath = true;

        while (currentNode.connectedTo != null)
        {
            currentNode = currentNode.connectedTo;
            currentNode.isPath = true;
            path.Add(currentNode);
        }

        path.Reverse();

        return path;
    }

    public bool WillBlockPath(Vector2Int coordinate)
    {
        if(_grid.ContainsKey(coordinate))
        {
            bool previousState = _grid[coordinate].isWalkable;

            _grid[coordinate].isWalkable = false;
            List<Node> newPath = GetNewPath();
            _grid[coordinate].isWalkable = previousState;

            if (newPath.Count <= 1)
            {
                GetNewPath();
                return true;
            }

        }
        
        return false;
    }

    public void NotifyReceivers()
    {
        BroadcastMessage("RecalculatePath", SendMessageOptions.DontRequireReceiver);
    }

}
