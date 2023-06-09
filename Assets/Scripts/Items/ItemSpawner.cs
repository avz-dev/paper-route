using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Sprite[] obstacleSprites;
    public float spawnRate;
    public float minHeight;
    public float maxHeight;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable() {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject obstacle = Instantiate(prefab, transform.position, Quaternion.identity);
        obstacle.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        obstacle.GetComponent<SpriteRenderer>().sprite = obstacleSprites[Random.Range(0, obstacleSprites.Length)];
    }
}
