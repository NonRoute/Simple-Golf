using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Golf golf = collision.gameObject.GetComponent<Golf>();
        if (golf != null)
        { 
            audioSource.Play();
            golf.score++;
            golf.scoreText.SetText("Score : " + golf.score);
            gameObject.SetActive(false);
        }
    }
}
