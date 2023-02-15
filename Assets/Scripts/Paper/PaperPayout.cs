using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPayout : MonoBehaviour
{
    public PiggyBank piggyBank;
    public Player player;
    private bool payed = false;

    private void Start() {
        player = FindObjectOfType<Player>();
        piggyBank = player.GetComponent<PiggyBank>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!payed && GetComponent<Rigidbody2D>().velocity == Vector2.zero) {
            GameObject house = other.transform.parent.gameObject;
            GameObject houseZone = other.gameObject; 
            house.SetActive(false);
            piggyBank.deposit(0);
            payed = true;
        }
        
    }
}
