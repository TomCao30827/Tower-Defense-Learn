using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpeedSetter : MonoBehaviour
{
    public EnemyMover[] enemyMovers;
    public GameObject objectPool;

    private void Start()
    {
       enemyMovers = objectPool.GetComponentsInChildren<EnemyMover>();
       if (enemyMovers.Length > 0) Debug.Log("Has enemy");
        else Debug.Log("Loi cmnr");
    }

    public void ChangeEnemySpeed(float newSpeed)
    {
        foreach (EnemyMover enemyMover in enemyMovers)
        {
            enemyMover._speed = newSpeed;
        }
    }
}
