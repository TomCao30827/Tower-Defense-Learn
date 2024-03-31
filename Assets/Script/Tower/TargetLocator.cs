using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _weapon;
    [SerializeField] private float _range = 15.0f;
    [SerializeField] private ParticleSystem _projectileParticle;

    private void Update()
    {
        FindCLosetTarget();
        AimWeapon();
    }

    private void FindCLosetTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closetTarget = null;
        float closetDistance = Mathf.Infinity;
        foreach (Enemy enemy in enemies)
        {
            float distance = Vector3.Distance(this.transform.position, enemy.transform.position); ;

            if (distance < closetDistance)
            {
                closetDistance = distance;
                closetTarget = enemy.transform;
            }
        }

        _target = closetTarget;
        
    }

    private void AimWeapon()
    {
        if (_target == null)
        {
            return;
        }

        float distance = Vector3.Distance(this.transform.position, _target.position);
        _weapon.LookAt(_target);

        if (distance < _range)
        {
            Attack(true);
        }
        
        else
        {
            Attack(false);
        }
    }

    private void Attack(bool isActive)
    {
        var emissionModule = _projectileParticle.emission;
        emissionModule.enabled = isActive;
    }

}
