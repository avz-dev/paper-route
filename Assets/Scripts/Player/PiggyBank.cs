using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PiggyBank : MonoBehaviour
{
    private float balance = 0f;
    public TextMeshProUGUI text;

    private void Start() {
        text.SetText(string.Format("{0:C}", balance));
    }

    // adds money to account
    public void deposit(float amount) {
        balance += amount;
        text.SetText(string.Format("{0:C}", balance));
    }

    // takes money from account
    public bool withdraw(float amount) {
        if (balance < amount) {
            return false;
        } else {
            balance -= amount;
            text.SetText(string.Format("{0:C}", balance));
            return true;
        }
    }

}
