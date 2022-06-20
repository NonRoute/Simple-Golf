using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sand : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Golf>() != null)
        {
            collision.gameObject.GetComponent<Golf>().isInSand = true;
            audioSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Golf>() != null)
        {
            collision.gameObject.GetComponent<Golf>().isInSand = false;
            audioSource.Play();
        }
    }
}
