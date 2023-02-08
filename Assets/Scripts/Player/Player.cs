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
        
        // Damage and healing debugging
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            CharacterTakeDmg(20);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            CharacterHeal(10);
        }
    }

    private void OnMove(InputValue inputValue) 
    {
        movementInput = inputValue.Get<Vector2>();
    }

    private void CharacterTakeDmg(int dmg)
    {
        GameManager.gameManager._characterHealth.DmgCharacter(dmg);
        Debug.Log(GameManager.gameManager._characterHealth.Health);
    }

    private void CharacterHeal(int healing)
    {
        GameManager.gameManager._characterHealth.HealCharacter(healing);
        Debug.Log(GameManager.gameManager._characterHealth.Health);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Ouch!");
        CharacterTakeDmg(20);
    }
    
}
