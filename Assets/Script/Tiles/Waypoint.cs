using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;

    [SerializeField] private bool _isPlacable = true;
    public bool IsPlacable { get { return _isPlacable; } }

    private void OnMouseDown()
    {
        if (_isPlacable)
        {
            Instantiate(towerPrefab, this.transform.position, Quaternion.identity);
        }
    }
}
