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

    public static int firstLevel = 0;
    public static int lastLevel = 5;
    public static int currentLevel = 1;

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

    public void QuitToMainMenu()
    {
        currentLevel = currentLevel - 1;
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
