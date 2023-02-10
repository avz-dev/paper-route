using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeValue = 60;
    public Text timerText;

    // decrement time every second (each frame)
    void Update()
    {
        if(timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        } 
        else 
        {
            timeValue = 0;
            // Load Gane Over Level Scene
            SceneManager.LoadScene(3); // MainMenu = 0, DeliveryGame = 1, GaneOverScreen = 2, LevelCompleteScreen = 3
        }

        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        // calculate minutes
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // set time to text
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
