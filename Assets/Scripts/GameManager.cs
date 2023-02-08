using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton used for global game management
    public static GameManager gameManager { get; private set; }

    // Construct new health system for player character, set current and max health
    public HealthSystem _characterHealth = new HealthSystem(100, 100);

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
}
