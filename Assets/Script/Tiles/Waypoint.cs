using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private bool _isPlacable = true;

    [SerializeField] private GameObject towerPrefab;

    private void OnMouseDown()
    {
        if (_isPlacable)
        {
            Instantiate(towerPrefab, this.transform.position, Quaternion.identity);
        }
    }
}
