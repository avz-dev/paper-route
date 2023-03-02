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
    public GameObject hud, pauseScreen;
    public PiggyBank piggyBank;
    public HouseSpawner houseSpawner;
    public BillboardSpawner billboardSpawner;
    private bool[] bikes = new bool[4];
    private Bike currentBike;
    private float[] bikePrices = {0f, 10f, 15f, 20f};
    public float nextLevelPrice = 15f;
    public DataSO playerData;
    public GameObject[] shopButtons;
    private bool isPaused = false;
    private bool isAtShop = false;
    private SoundManager soundManager;

    private void Start()
    {
        currentBike = gameObject.AddComponent<Bike>();
        bikes = playerData.Bikes;
        soundManager = GetComponent<SoundManager>();
    }

    private void Update() 
    {
        if (bikeShop != null && bikeShop.transform.position.x < -0.5f) 
        {
            EndGame();
            bikeShop = null;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            PauseGame();
            isPaused = !isPaused;
        }
    }

    // transition route to shop menu
    public void EndGame() 
    {
        WriteSummary();
        ShowPurchasable();
        gameOverScreen.SetActive(true);
        finalPiggyBankBalance.SetText(currentPiggyBankBalance.text);
        hud.SetActive(false);
        playerReference.PausePlayer(false);
        isAtShop = true;
        Time.timeScale = 0;
    }

    // Move
    public void GoToNextLevel() 
    {
        Time.timeScale = 1;
        GameManager.gameManager.StartGame();
    }

    public void PauseGame() 
    {
        soundManager.PlaySound(4);
        if (isAtShop) {
            gameOverScreen.SetActive(isPaused);
        } else {
            hud.SetActive(isPaused);
            playerReference.PausePlayer(isPaused);
        }

        pauseScreen.SetActive(!isPaused);
        
        if (isPaused && !isAtShop) Time.timeScale = 1;
        else Time.timeScale = 0;
    }


    public void RestartRoute() 
    {
        gameOverScreen.SetActive(false);
        playerReference.transform.position = new Vector2(0, -3);
        playerReference.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        hud.SetActive(true);
        playerReference.RestockPaper();
        StartSpawning();
        playerReference.PausePlayer(true);
        isAtShop = false;
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
        houseSpawner.progressBar.SetProgress(0);
        spawners.SetActive(true);
        billboardSpawner.SpawnBillboard();
    }

    public void SelectBike(int bikeOption) 
    {
        if (bikes[bikeOption] || piggyBank.withdraw(bikePrices[bikeOption])) {
            switch (bikeOption)
            {
                case 1: 
                    if (!bikes[bikeOption]) shopButtons[1].transform.GetChild(0).gameObject.SetActive(false); 
                    playerData.Bicycle = gameObject.AddComponent<BasketBike>();
                    break;
                case 2: 
                    if (!bikes[bikeOption]) shopButtons[2].transform.GetChild(0).gameObject.SetActive(false); 
                    playerData.Bicycle = gameObject.AddComponent<RoadBike>();
                    break;
                case 3:
                    if (!bikes[bikeOption]) shopButtons[3].transform.GetChild(0).gameObject.SetActive(false); 
                    playerData.Bicycle = gameObject.AddComponent<MountainBike>();
                    break;
                default: 
                    playerData.Bicycle = gameObject.AddComponent<Bike>();
                    break;
            }
            bikes[bikeOption] = true;
            playerData.Bikes = bikes;
            currentBike = playerData.Bicycle;
            GameManager.currentBike = currentBike;
            playerReference.SetBike(currentBike); 
            ShowPurchasable();           
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

    public void PurchaseNextLevel()
    {    
        if (piggyBank.GetBalance() >= nextLevelPrice)
        {
            piggyBank.withdraw(nextLevelPrice);
            Time.timeScale = 1;
            GameManager.gameManager.StartGame();
        }
    }

    private void ShowPurchasable()
    {
        for (int i = 1; i < 4; i++)
        {
            if (!bikes[i] && bikePrices[i] > piggyBank.GetBalance()) {
                shopButtons[i].GetComponent<Image>().color = new Color(0.7f, 0.7f, 0.7f, 1f);
            } else {
                shopButtons[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            } 
        }

        if (piggyBank.GetBalance() < nextLevelPrice) {
            shopButtons[0].GetComponent<Image>().color = new Color(0.7f, 0.7f, 0.7f, 1f);
        } else {
            shopButtons[0].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        } 
    }
}
