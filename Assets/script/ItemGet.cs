using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemGet : MonoBehaviour
{
    public AudioClip coinGet;
    public TextMeshProUGUI coinLabel;
    private int coinCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            AudioSource.PlayClipAtPoint(coinGet, transform.position);

            Destroy(collision.gameObject);

            coinCount += 1;
            coinLabel.text = "" + coinCount;
        }
    }
}