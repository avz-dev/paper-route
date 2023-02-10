using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    // Fields
    int _currentMoney;
    int _currentStartMoney;
    public Text moneyText;

    // Properties
    public int Money
    {
        get
        {
            return _currentMoney;
        }
        set
        {
            _currentMoney = value;
        }
    }

    public int StartMoney
    {
        get
        {
            return _currentStartMoney;
        }
        set
        {
            _currentStartMoney = value;
        }
    }

    // Constructor
    public Wallet(int money, int startMoney)
    {
        _currentMoney = money;
        _currentStartMoney = startMoney;
    }

    // Methods
    public void EraseMoney()
    {
        _currentMoney = 0;
    }

    public void AddMoney(int money)
    {
        _currentMoney = _currentMoney + money;
    }

    public void DisplayWallet()
    {
        moneyText.text = string.Format("{}", _currentMoney);
    }

}
