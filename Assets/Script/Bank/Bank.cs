using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] private int _startMoney = 150;
    [SerializeField] private int _currentBalance;
    [SerializeField] private TextMeshProUGUI _displayBalance;
    public int CurrentBalance {  get { return _currentBalance; } }

    private void Awake()
    {
        _currentBalance = _startMoney;
        _displayBalance.enabled = false;
        UpdateDisplay();
    }

    private void Update()
    {
        ToggleGold();
    }

    public void Deposit(int amount)
    {
        _currentBalance += amount;

        UpdateDisplay();
    }

    public void Withdraw(int amount)
    {
        _currentBalance -= amount;

        UpdateDisplay();

        if (_currentBalance < 0)
        {
           ReloadScene();
        }
    }

    private void UpdateDisplay()
    {
        _displayBalance.text = "Gold: " + _currentBalance.ToString();
    }

    private void ToggleGold()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _displayBalance.enabled = !_displayBalance.enabled;
        }
    }

    private void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
