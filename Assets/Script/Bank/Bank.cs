using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] private int _startMoney = 150;
    [SerializeField] private int _currentBalance;

    private void Awake()
    {
        _currentBalance = _startMoney;
    }

    public void Deposit(int amount)
    {
        _currentBalance += amount;
    }

    public void Withdraw(int amount)
    {
        _currentBalance -= amount;
        if (_currentBalance < 0)
        {
            _currentBalance = 0;
        }

    }
}
