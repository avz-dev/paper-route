using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem
{
    // Fields
    int _currentHealth;
    int _currentMaxHealth;

    // Properties
    public int Health
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
        }
    }

    public int MaxHealth
    {
        get
        {
            return _currentMaxHealth;
        }
        set
        {
            _currentMaxHealth = value;
        }
    }

    // Constructor
    public HealthSystem(int health, int maxHealth)
    {
        _currentHealth = health;
        _currentMaxHealth = maxHealth;
    }

    // Methods
    public void DmgCharacter(int dmgAmount)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= dmgAmount;
            if (_currentHealth <= 0)
            {
                // Load Gane Over Level Scene
                SceneManager.LoadScene(2); // MainMenu = 0, DeliveryGame = 1, GaneOverScreen = 2, LevelCompleteScreen = 3
            }
        }

    }

    public void HealCharacter(int healAmount)
    {
        if (_currentHealth < _currentMaxHealth)
        {
            _currentHealth += healAmount;
        }
        if (_currentHealth > _currentMaxHealth)
        {
            _currentHealth = _currentMaxHealth;
        }
    }
}
