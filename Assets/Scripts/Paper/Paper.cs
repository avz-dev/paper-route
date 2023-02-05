using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    public float speed = 5f;
    public float idleSpeed;
    private float leftEdge;
    public Rigidbody2D rigidbod;
    
    void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        rigidbod.velocity = transform.up * speed;   
    }

    private void FixedUpdate() 
    {
        transform.position += Vector3.left * idleSpeed * Time.deltaTime;
        if (rigidbod.velocity != Vector2.zero) 
        {
            rigidbod.velocity = rigidbod.velocity / 1.05f; 
            Debug.Log(rigidbod.velocity);
        }

        if (transform.position.x < leftEdge) {
            Destroy(gameObject);
        }
    }

}
