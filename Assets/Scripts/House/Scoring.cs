using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public Player playerReference;
    public PiggyBank piggyBank;
    public GameObject houseZone;
    public GameObject floatingTextprefab;
    public float rate;
    private bool payed = false;
    
    private void Start() {
        playerReference = FindObjectOfType<Player>();
        piggyBank = playerReference.GetComponent<PiggyBank>();
    }

    private void OnTriggerStay2D(Collider2D other) {
        // once paper has stopped, increment piggy bank
        if (!payed && other.transform.parent.GetComponent<Rigidbody2D>().velocity == Vector2.zero) {
            houseZone.SetActive(false);
            piggyBank.deposit(rate);    
            piggyBank.deposit(0);
            showPay(other);
            payed = true;
        }
    }

    // instantiate text to show pay out
    private void showPay(Collider2D other) {
        if (floatingTextprefab) {
            int rateAsInt = (int)(rate * 100);
            string rateAsString = "+" + rateAsInt.ToString() + "¢";
            GameObject prefab = Instantiate(floatingTextprefab, other.transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = rateAsString;
        }
    }
}
