using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingArm : MonoBehaviour
{
    public Transform throwPoint;
    public GameObject paperPrefab;
    public GameObject powerBarVisual;
    public PowerBar powerBar;
    public float startingStength = 2f;
    public float startingIncrement = .25f;
    private float strengthLevel;
    private float strengthIncrement;

    void Start()
    {
        powerBarVisual.SetActive(false);
        strengthLevel = startingStength;
        strengthIncrement = startingIncrement;
    }
    
    void Update()
    {
        if (strengthLevel > 12f || strengthLevel < 2f) {
            strengthIncrement *= -1;
        }

        if (Input.GetButton("Fire1"))
        {
            strengthLevel += strengthIncrement;
            powerBar.SetPower((int) strengthLevel);
            powerBarVisual.SetActive(true);
        }

        if (Input.GetButtonUp("Fire1"))
            {
                paperPrefab.GetComponent<Paper>().speed = strengthLevel;
                Shoot();
                strengthLevel = startingStength;
                strengthIncrement = startingIncrement;
                powerBarVisual.SetActive(false);
            }

    }

    private void Shoot() 
    {
        Instantiate(paperPrefab, throwPoint.position, throwPoint.rotation);
    }
}
