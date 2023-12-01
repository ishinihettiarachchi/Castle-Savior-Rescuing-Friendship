using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    private int coins = 0;
    [SerializeField] private Text coinText;
    [SerializeField] private AudioSource coinCollectSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            coinCollectSoundEffect.Play();
            Destroy(collision.gameObject);
            coins++;
            coinText.text = "Coins:" + coins;
        }
    }
}
