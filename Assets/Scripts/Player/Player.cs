using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbod;
    [SerializeField] private float movementSpeed;
    public SpriteRenderer sprite;
    private Vector2 movementInput;
    private Vector2 smoothedMovementInput;
    private Vector2 smoothVelocity;
    public float idleSpeed;

    private void Update() 
    {
        // movement
        smoothedMovementInput = Vector2.SmoothDamp(
            smoothedMovementInput,
            movementInput,
            ref smoothVelocity,
            0.1f);
        rigidbod.velocity = movementInput * movementSpeed;
        //transform.position += Vector3.left * idleSpeed * Time.deltaTime;
        
        // damage and healing debugging
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

    // damage character
    private void CharacterTakeDmg(int dmg)
    {
        GameManager.gameManager._characterHealth.DmgCharacter(dmg);
        Debug.Log(GameManager.gameManager._characterHealth.Health);
    }

    // heal character
    private void CharacterHeal(int healing)
    {
        GameManager.gameManager._characterHealth.HealCharacter(healing);
        Debug.Log(GameManager.gameManager._characterHealth.Health);
    }

    // character take damage when colliding with Obstacle
    private void OnCollisionEnter2D(Collision2D other) 
    {
        
        if (other.gameObject.tag == "Obstacle") 
        {
            StartCoroutine(VisualizeDamage());
            CharacterTakeDmg(20);
            movementSpeed -= .3f;
        }
    }
    
    // visualize damage when character takes damage
    private IEnumerator VisualizeDamage()
    {
        sprite.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.black;
    }
}
