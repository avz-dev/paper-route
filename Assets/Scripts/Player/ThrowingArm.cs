using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingArm : MonoBehaviour
{
    public Transform throwPoint;
    public GameObject paperPrefab;
    public GameObject powerBarVisual;
    public PowerBar powerBar;
    public Player player;
    public float startingStength = 2f;
    public float startingIncrement = .25f;
    private float strengthLevel;
    private float strengthIncrement;

    void Start()
    {
        powerBarVisual.SetActive(false);
        strengthLevel = startingStength;
        strengthIncrement = startingIncrement;
        player = GetComponent<Player>(); 
    }
    
    void Update()
    {
        // alternates direction of power meter growth
        if (strengthLevel > 12f || strengthLevel < 2f) {
            strengthIncrement *= -1;
        }
        // updates power meter while button is pressed
        if (Input.GetButton("Fire1"))
        {
            strengthLevel += strengthIncrement;
            powerBar.SetPower((int) strengthLevel);
            powerBarVisual.SetActive(true);
        }
        // instantiate paper with velocity base on power meter, reset power meter
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
