using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HomeBaseManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject spawners;
    public GameObject bikeShop;
    public Player playerReference;
    public TextMeshProUGUI finalPiggyBankBalance;
    public TextMeshProUGUI currentPiggyBankBalance;
    public TextMeshPro summaryText;
    public GameObject hud;
    public PiggyBank piggyBank;
    private bool[] bikes = new bool[3];
    private Bike currentBike;
    public DataSO playerData;

    private void Start()
    {
        currentBike = gameObject.AddComponent<Bike>();
        bikes[0] = true;
    }

    private void Update() 
    {
        if (bikeShop != null && bikeShop.transform.position.x < -0.5f) 
        {
            EndGame();
            bikeShop = null;
        }
    }

    // transition route to shop menu
    public void EndGame() 
    {
        WriteSummary();
        gameOverScreen.SetActive(true);
        finalPiggyBankBalance.SetText(currentPiggyBankBalance.text);
        hud.SetActive(false);
        Time.timeScale = 0;
    }

    public void RestartGame() 
    {
        Time.timeScale = 1;
        GameManager.gameManager.StartGame();
    }

    public void RestartRoute() 
    {
        gameOverScreen.SetActive(false);
        hud.SetActive(true);
        playerReference.RestockPaper();
        StartSpawning();
        Time.timeScale = 1;
    }

    public void SetBikeShop(GameObject bikeShop) 
    {
        this.bikeShop = bikeShop;
    }

    public void StopSpawning() 
    {
        spawners.SetActive(false);
    }

    public void StartSpawning() 
    {
        spawners.SetActive(true);
    }

    public void SelectBike(int bikeOption, float bikeCost) 
    {
        if (bikes[bikeOption] || piggyBank.withdraw(bikeCost)) {
            switch (bikeOption)
            {
                case 1: 
                    currentBike = gameObject.AddComponent<BasketBike>();
                    break;
                case 2: 
                    currentBike = gameObject.AddComponent<RoadBike>();
                    break;
                case 3: 
                    currentBike = gameObject.AddComponent<MountainBike>();
                    break;
                default: 
                    currentBike = gameObject.AddComponent<Bike>();
                    break;
            }
            bikes[bikeOption] = true;
            GameManager.currentBike = currentBike;
            playerReference.SetBike(currentBike);

            playerData.Bikes = bikes;
            playerData.Bicycle = currentBike;
        }
    }

    public void WriteSummary() 
    {
        float bonus = piggyBank.CalculateBonus();
        summaryText.SetText(string.Format("{0:C}\n{1:C}\n\n{2:C}", 
                        piggyBank.currentPaycheck, bonus,
                        piggyBank.currentPaycheck + bonus));
        piggyBank.ClearPaycheck();
    }
}
