using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rigidbod;
    
    void Start()
    {
        rigidbod.velocity = transform.up * speed;   
    }

    private void FixedUpdate() 
    {
        transform.position += Vector3.left * 1.8f * Time.deltaTime;
        if (rigidbod.velocity != Vector2.zero) 
        {
            rigidbod.velocity = rigidbod.velocity / 1.05f; 
            Debug.Log(rigidbod.velocity);
        }
    }

}
