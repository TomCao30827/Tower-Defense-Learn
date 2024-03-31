using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    private TextMeshPro _label;
    private Color _defaultColor = Color.white;
    private Color _blockedColor = Color.gray;

    private Vector2Int _coordinate = new Vector2Int();
    private Waypoint _waypoint;

    private void Awake()
    {
        _label = GetComponent<TextMeshPro>();
        _label.enabled = true;
         
        _waypoint = GetComponentInParent<Waypoint>();

        DisplayCoordinates();
    }

    private void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
        ColorCoordiate();
        ToggleLabels();
    }

    private void ColorCoordiate()
    {
        if (_waypoint.IsPlacable)
        {
            _label.color = _defaultColor;
        }

        else
        {
            _label.color = _blockedColor;
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
        _coordinate.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        _coordinate.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.y);
        
        _label.text = _coordinate.x + "," + _coordinate.y;
    }

    private void UpdateObjectName()
    {
        transform.parent.name = _coordinate.ToString();
    }
}
