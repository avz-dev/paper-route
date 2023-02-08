using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameScript : MonoBehaviour
{
    // Exit the game application (will not function in Unity editor, but will be functional in built application)
    public void ExitGame()
    {
        Application.Quit();
    }
}
