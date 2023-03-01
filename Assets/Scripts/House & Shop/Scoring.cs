using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public GameManager gm;
    public PiggyBank piggyBank;
    public GameObject houseZone;
    public GameObject floatingTextprefab;
    public Color rateColor;
    public float rate;
    private bool payed = false;
    
    private void Start() {
        gm = FindObjectOfType<GameManager>();
        piggyBank = gm.GetComponent<PiggyBank>();
    }

    private void OnTriggerStay2D(Collider2D other) {
        // once paper has stopped, increment piggy bank
        if (!payed && other.transform.parent.GetComponent<Rigidbody2D>().velocity == Vector2.zero) {
            houseZone.SetActive(false);
            piggyBank.deposit(rate);    
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
            prefab.GetComponentInChildren<TextMesh>().color = rateColor;
        }
    }
}
