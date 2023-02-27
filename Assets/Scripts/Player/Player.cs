using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbod;
    [SerializeField] private float movementSpeed;
    [SerializeField] private HomeBaseManager homeBaseManager;
    public ThrowingArm throwingArm;
    public TextMeshProUGUI healthText;
    public SpriteRenderer sprite;
    public Animator bikeAnim;
    public AnimationClip[] bikeAnimations;
    public Sprite[] bikeSprites;
    private Vector2 movementInput;
    private Vector2 smoothedMovementInput;
    private Vector2 smoothVelocity;
    public Color healingColor;
    public Color damageColor;
    public float idleSpeed;
    public float slideDuration;
    public float stunDuration;
    public int paperCount;
    public DataSO playerData;
    private bool isStunned = false;
    private bool isSliding = false; 


    private void Awake() {
        Bike bike = playerData.Bicycle;
        if (bike == null) {
            playerData.Bicycle = bike = gameObject.AddComponent<Bike>();
        }
        SetBike(bike);
    }

    private void Update() 
    {
        if (!isStunned) {
            // movement
            smoothedMovementInput = Vector2.SmoothDamp(
                smoothedMovementInput,
                movementInput,
                ref smoothVelocity,
                0.1f);
            rigidbod.velocity = movementInput * movementSpeed;
            //transform.position += Vector3.left * idleSpeed * Time.deltaTime;
        }
    }

    private void OnMove(InputValue inputValue) 
    {
        if (!isSliding) {
           movementInput = inputValue.Get<Vector2>(); 
        }
    }

    // character take damage when colliding with obstacles
    private void OnCollisionEnter2D(Collision2D other) 
    {
        
        if (other.gameObject.tag == "Obstacle") 
        {
            throwingArm.ResetShot();
            StartCoroutine(VisualizeDamage());
            StartCoroutine(Stun());
            other.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Slippery"){
            throwingArm.ResetShot();
            StartCoroutine(VisualizeDamage());
            StartCoroutine(Slide());
        }
    }
    
    // Stun player for the given stun duration
    private IEnumerator Stun()
    {
        throwingArm.isStunned = true;
        yield return new WaitForSeconds(0.1f);
        rigidbod.velocity = Vector2.zero;
        isStunned = true;
        yield return new WaitForSeconds(stunDuration);
        isStunned = false;
        throwingArm.isStunned = false;
    }

    // Make player slide for the the current slideDuration
    private IEnumerator Slide()
    {
        throwingArm.isStunned = isSliding = true;
        yield return new WaitForSeconds(slideDuration);
        throwingArm.isStunned = isSliding = false;
    }

    // visualize damage when character collides with item
    private IEnumerator VisualizeDamage() {
        int i = 3;
        while (i > 0) {
            sprite.color = new Color(1f, 1f, 1f, .6f);
            yield return new WaitForSeconds(0.2f);
            sprite.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.2f);
            i--;
        }
    }

    // Change parameters based on given bike
    public void SetBike(Bike bike)
    {   
        paperCount = bike.paperCapacity;
        slideDuration = bike.slideDuration;
        stunDuration = bike.stunDuration;
        movementSpeed = bike.bikeSpeed;
        sprite.sprite = bikeSprites[bike.bikeSpriteIndex];
        bikeAnim.Play(bike.bikeAnimation);
    }

    public void RestockPaper()
    {
        throwingArm.paperCount = paperCount;
        throwingArm.paperText.SetText(string.Format("{0}", paperCount));
    }
}
