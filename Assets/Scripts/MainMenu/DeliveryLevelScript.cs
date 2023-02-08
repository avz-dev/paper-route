using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeliveryLevelScript : MonoBehaviour
{

    public void LoadGame()
    {
        // Load Delivery Level Scene
        SceneManager.LoadScene(1); // MainMenu = 0, DeliveryGame = 1
    }
}
