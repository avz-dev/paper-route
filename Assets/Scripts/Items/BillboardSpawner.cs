using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardSpawner : MonoBehaviour
{
    public GameObject billboardRef;
    private GameObject billboard;
    public Sprite[] billboardSprites;

    public void SpawnBillboard() 
    {
        billboard = Instantiate(billboardRef, transform.position, Quaternion.identity);
        billboard.GetComponent<SpriteRenderer>().sprite = billboardSprites[Random.Range(0, billboardSprites.Length)];
    }
}
