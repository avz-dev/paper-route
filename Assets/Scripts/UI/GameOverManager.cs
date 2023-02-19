using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public TextMeshProUGUI finalPiggyBankBalance;
    public TextMeshProUGUI currentPiggyBankBalance;
    public GameObject hud;

    public void EndGame() {
        gameOverScreen.SetActive(true);
        finalPiggyBankBalance.SetText(currentPiggyBankBalance.text);
        hud.SetActive(false);
        Time.timeScale = 0;
    }

    public void RestartGame() {
        Time.timeScale = 1;
        GameManager.gameManager.StartGame();
    }
}
