using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            CharacterTakeDmg(20);
            Debug.Log(GameManager.gameManager._characterHealth.Health);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            CharacterHeal(10);
            Debug.Log(GameManager.gameManager._characterHealth.Health);
        }
    }

    private void CharacterTakeDmg(int dmg)
    {
        GameManager.gameManager._characterHealth.DmgCharacter(dmg);
        Debug.Log(GameManager.gameManager._characterHealth.Health);
    }

    private void CharacterHeal(int healing)
    {
        GameManager.gameManager._characterHealth.HealCharacter(healing);
        Debug.Log(GameManager.gameManager._characterHealth.Health);
    }

}
