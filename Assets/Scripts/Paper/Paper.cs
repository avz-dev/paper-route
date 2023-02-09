using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    public float speed;
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
            transform.Rotate (Vector3.forward * -5);
            rigidbod.velocity = rigidbod.velocity / 1.05f; 
            if (rigidbod.velocity.y < 0.5f && rigidbod.velocity.y > -0.5f) 
            {
                rigidbod.velocity = Vector2.zero;
            }
            Debug.Log(rigidbod.velocity.y);
        }

        if (transform.position.x < leftEdge) {
            Destroy(gameObject);
        }
    }

}
