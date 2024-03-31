using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _maxHitPoint = 5;
    [SerializeField] private int _currentHitPoint;

    private Enemy _enemy;
    private void OnEnable()
    {
        _currentHitPoint = _maxHitPoint;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        _currentHitPoint--;

        if (_currentHitPoint < 1 )
        {
            _enemy.RewardGold();
            Destroy(this.gameObject);
        }
    }
}
