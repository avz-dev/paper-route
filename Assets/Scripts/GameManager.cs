using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Singleton used for global game management
    public static GameManager gameManager { get; private set; }

    // Construct new health system for player character, set current and max health
    public HealthSystem _characterHealth = new HealthSystem(100, 100);

    public static int firstLevel = 1;
    public static int lastLevel = 4;
    public static int currentLevel = firstLevel;

    public static float currentPiggyBankBalance = 0f;
    public static Bike currentBike;

    void Awake()
    {
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }
    }

    public void StartGame() 
    {
        if (currentLevel > lastLevel) {
            currentLevel = firstLevel;
        }
        
        SceneManager.LoadScene(currentLevel);
        currentLevel++;
    }

    public void QuitGame() 
    {
        Application.Quit();
    }

    public float GetPiggyBank()
    {
        return currentPiggyBankBalance;
    }

    public void StuffPiggyBank(float deposit)
    {
        currentPiggyBankBalance += deposit;
    }

    public bool BreakPiggyBank(float cost)
    {
        if (currentPiggyBankBalance < cost) {
            return false;
        } else {
            currentPiggyBankBalance -= cost;
            return true;
        }
    }
}
