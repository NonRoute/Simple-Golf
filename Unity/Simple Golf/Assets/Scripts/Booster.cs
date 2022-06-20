using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField]
    private float _launchPower = 1;
    [SerializeField]
    private Vector3 direction;
    [SerializeField]
    private AudioSource audioSource;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Golf>() != null)
        {
            collision.gameObject.GetComponent<Golf>().GetComponent<Rigidbody2D>().AddForce(direction * _launchPower);
            audioSource.Play();
        }
    }
}
