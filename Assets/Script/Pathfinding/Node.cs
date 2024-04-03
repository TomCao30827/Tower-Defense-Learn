using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]  
public class Node 
{
    public Vector2Int coordiante;
    public bool isWalkable;
    public bool isExplored;
    public bool isPath;
    public bool connectedTo;

    public Node(Vector2Int coordinate, bool isWalkable)
    {
        this.coordiante = coordinate;
        this.isWalkable = isWalkable;
    }

}
