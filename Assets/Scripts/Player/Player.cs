using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbod;
    [SerializeField] private float movementSpeed;
    private Vector2 movementInput;
    private Vector2 smoothedMovementInput;
    private Vector2 smoothVelocity;
    public float idleSpeed;

    private void Update() 
    {
        smoothedMovementInput = Vector2.SmoothDamp(
            smoothedMovementInput,
            movementInput,
            ref smoothVelocity,
            0.1f);
        rigidbod.velocity = movementInput * movementSpeed;
        transform.position += Vector3.left * idleSpeed * Time.deltaTime;
    }

    private void OnMove(InputValue inputValue) 
    {
        movementInput = inputValue.Get<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Ouch!");
    }
    
}
