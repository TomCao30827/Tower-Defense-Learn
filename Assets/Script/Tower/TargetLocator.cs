using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform weapon;

    private void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
    }

    private void Update()
    {
        
    }

    private void AimWeapon()
    {

    }

}
