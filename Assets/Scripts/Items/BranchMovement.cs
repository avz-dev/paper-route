using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchMovement : MonoBehaviour
{
    public float speed = 1.5f;
    private float leftEdge, colliderEdge;
    private void Start() {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        colliderEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x + 1.8f;
    }

    private void Update() {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftEdge) {
            Destroy(gameObject);
        }

        if (transform.position.x < colliderEdge) {
            gameObject.GetComponent<Collider2D>().isTrigger = true;
            gameObject.GetComponent<SpriteRenderer>().spriteSortPoint = SpriteSortPoint.Center;
        }
    }
}
