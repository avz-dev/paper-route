using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingArm : MonoBehaviour
{
    public Transform throwPoint;
    public GameObject paperPrefab;
    public PowerBar powerBar;
    public float strengthLevel = 3f;
    public float strengthIncrement = 0.1f;
    
    void Update()
    {
        if (strengthLevel > 10f || strengthLevel < 3f) {
            strengthIncrement *= -1;
        }

        if (Input.GetButton("Fire1"))
        {
            strengthLevel += strengthIncrement;
            powerBar.SetPower((int) strengthLevel);
        }

        if (Input.GetButtonUp("Fire1"))
            {
                paperPrefab.GetComponent<Paper>().speed = strengthLevel;
                Shoot();
                strengthLevel = 3f;
                strengthIncrement = 0.1f;
            }

    }

    private void Shoot() 
    {
        Instantiate(paperPrefab, new Vector3(throwPoint.transform.position.x, throwPoint.transform.position.y, 1), throwPoint.rotation);
    }
}
