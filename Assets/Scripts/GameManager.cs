using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton used for global game management
    public static GameManager gameManager { get; private set; }

    // Construct new health system for player character, set current and max health
    public HealthSystem _characterHealth = new HealthSystem(100, 100);

    // Construct new wallet for player character, set current and starting money
    //public Wallet _characterMoney = new Wallet(20, 20);

    public static int firstLevel = 1;
    public static int lastLevel = 4;
    public static int currentLevel = firstLevel;

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

    public void StartGame() {
        if (currentLevel > lastLevel) {
            currentLevel = firstLevel;
        }
        
        SceneManager.LoadScene(currentLevel);
        currentLevel++;
    }
}
