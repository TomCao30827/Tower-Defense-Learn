using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [Tooltip("Increase enemy by 1 when it is destroyed")]
    [SerializeField] private int _difficultiRamp = 1;

    [SerializeField] private int _maxHitPoint = 5;
    [SerializeField] private int _currentHitPoint;

    private Enemy _enemy;
    private void OnEnable()
    {
        _currentHitPoint = _maxHitPoint;
    }

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
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
            _maxHitPoint += _difficultiRamp;
            this.gameObject.SetActive(false);
        }
    }
}
