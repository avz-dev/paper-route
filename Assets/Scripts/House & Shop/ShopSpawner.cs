using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSpawner : MonoBehaviour
{
    public GameObject bikeShopReference;
    private GameObject bikeShop;
    public Sprite sprite;
    public HomeBaseManager homeBaseManager;

    public void SpawnBikeShop() 
    {
        bikeShop = Instantiate(bikeShopReference, transform.position, Quaternion.identity);
        bikeShop.GetComponent<SpriteRenderer>().sprite = sprite;
        homeBaseManager.SetBikeShop(bikeShop);
        homeBaseManager.StopSpawning();
    }
}
