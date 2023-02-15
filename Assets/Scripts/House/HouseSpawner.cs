using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Player playerReference;
    public float spawnRate;
    public float height;
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
        GameObject obstacle = Instantiate(prefab, transform.position, Quaternion.identity);
        obstacle.transform.position += Vector3.up * height;
        housesPassed++;
    }
}
