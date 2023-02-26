using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{
    public GameObject prefab;
    public ShopSpawner shopSpawner;
    public Player playerReference;
    public Sprite[] houseSprites;
    public float spawnRate;
    public float height;
    public float bikeShopHeight = 1.85f;
    public int maxHouses = 4;
    public int housesPassed = 0;

    private void Start() {
        // passes the player to each house instantiation, used for scoring
        playerReference = GetComponent<Player>();
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable() {
        CancelInvoke(nameof(Spawn));
    }

    // spawn houses
    private void Spawn()
    {
        GameObject house = Instantiate(prefab, transform.position, Quaternion.identity);
        house.GetComponent<SpriteRenderer>().sprite = houseSprites[Random.Range(0, 6)];
        house.transform.position += Vector3.up * height;
        housesPassed++;
        // spawn bike shop & kill spawners when maxHouses is reached 
        if (housesPassed >= maxHouses) {
            maxHouses = 0;
            shopSpawner.SpawnBikeShop();
        }
    }

}
