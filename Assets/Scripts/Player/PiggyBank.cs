using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PiggyBank : MonoBehaviour
{
    private GameManager gm;
    private float balance = 0f;
    public float currentPaycheck;
    public TextMeshProUGUI hudText;
    public TextMeshProUGUI homeBaseText;
    public DataSO playerData;

    private void Start() {
        balance = playerData.Balance;
        UpdateText();
        gm = GetComponent<GameManager>();
    }

    // adds money to account
    public void deposit(float amount) {
        balance += amount;
        playerData.Balance += amount;
        currentPaycheck += amount;
        gm.StuffPiggyBank(amount);
        UpdateText();
    }

    // takes money from account
    public bool withdraw(float amount) {
        if (balance < amount) {
            return false;
        } else {
            balance -= amount;
            playerData.Balance -= amount;
            UpdateText();
            return true;
        }
    }

    public void ClearPaycheck() 
    {
        currentPaycheck = 0f;
    }

    public float CalculateBonus() 
    {
        float bonus;
        if (currentPaycheck >= 7.5f)
        {
            bonus = 3f;
        }
        else if (currentPaycheck >= 5f)
        {
            bonus = 2f;
        }
        else if (currentPaycheck >= 2.5f)
        {
            bonus = 1f;
        }
        else
        {
            bonus = 0f;
        }
        balance += bonus;
        playerData.Balance += bonus;
        return bonus;
    }

    public void UpdateText() {
        hudText.SetText(string.Format("{0:C}", balance));
        homeBaseText.SetText(string.Format("{0:C}", balance));
    }

    public float GetBalance()
    {
        return balance;
    }
}
