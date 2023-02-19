using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbod;
    [SerializeField] private float movementSpeed;
    [SerializeField] private GameOverManager gameOverManager;
    public TextMeshProUGUI healthText;
    public SpriteRenderer sprite;
    private Vector2 movementInput;
    private Vector2 smoothedMovementInput;
    private Vector2 smoothVelocity;
    public Color healingColor;
    public Color damageColor;
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
        GameManager.gameManager._characterHealth.updateHealthText(healthText);
        if (GameManager.gameManager._characterHealth.IsDead()) {
            gameOverManager.EndGame();
        }
    }

    // heal character
    private void CharacterHeal(int healing)
    {
        GameManager.gameManager._characterHealth.HealCharacter(healing);
        GameManager.gameManager._characterHealth.updateHealthText(healthText);
    }

    // character take damage when colliding with Obstacle
    private void OnCollisionEnter2D(Collision2D other) 
    {
        
        if (other.gameObject.tag == "Obstacle") 
        {
            StartCoroutine(VisualizeCollision(damageColor));
            CharacterTakeDmg(20);
            movementSpeed -= .4f;
        } else if (other.gameObject.tag == "Health"){
            StartCoroutine(VisualizeCollision(healingColor));
            CharacterHeal(20);
            movementSpeed += .4f;
            Destroy(other.gameObject);
        }
        Destroy(other.gameObject);
    }
    
    // visualize damage/healing when character collides with item
    private IEnumerator VisualizeCollision(Color effectColor)
    {
        sprite.color = effectColor;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
    }

   
}
