using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{
    public GameObject prefab;

    public float spawnRate;
    public float height;

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
        obstacle.transform.position += Vector3.up * height;
    }
}
