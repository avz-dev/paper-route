using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMovement : MonoBehaviour
{
    public float speed;
    private float leftEdge;
    public float offset;

    private void Start() {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - offset;
    }

    private void Update() {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftEdge) {
            Destroy(gameObject);
        }
    }
}
