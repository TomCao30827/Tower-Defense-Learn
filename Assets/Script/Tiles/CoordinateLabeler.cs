using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    private TextMeshPro _label;
    private Color _defaultColor = Color.white;
    private Color _blockedColor = Color.gray;
    private Color _exploredColor = Color.yellow;
    private Color _pathColor = new Color(1.0f, 0.5f, 0.0f);

    private Vector2Int _coordinate = new Vector2Int();
    private GridManager _gridManager;

    private void Awake()
    {
        _gridManager = FindObjectOfType<GridManager>();
        _label = GetComponent<TextMeshPro>();
        _label.enabled = true;
         

        DisplayCoordinates();
    }

    private void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
        SetLabelColor();
        ToggleLabels();
    }

    private void SetLabelColor()
    {
        if (_gridManager == null) { return; }

        Node node = _gridManager.GetNode(_coordinate);

        if (node == null) { return; }

        if (!node.isWalkable)
        {
            _label.color = _blockedColor;
        }

        else if (node.isPath)
        {
            _label.color = _pathColor;
            
        }

        else if (node.isExplored)
        {
            _label.color = _exploredColor;
        }

        else
        {
            _label.color = _defaultColor;
        }
    }

    private void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _label.enabled = !_label.enabled;
        }
    }

    private void DisplayCoordinates()
    {
        //Cant directly use because of conflict when using editor's attributes.
        //_coordinate.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        //_coordinate.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.y);

        _coordinate.x = Mathf.RoundToInt(transform.parent.position.x / 10);
        _coordinate.y = Mathf.RoundToInt(transform.parent.position.z / 10);

        _label.text = _coordinate.x + "," + _coordinate.y;
    }

    private void UpdateObjectName()
    {
        transform.parent.name = _coordinate.ToString();
    }
}
