using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSeconds : MonoBehaviour
{

    public float secondsToDestroy = 1f;
    
    void Update()
    {
        Destroy(gameObject, secondsToDestroy);
    }
}
