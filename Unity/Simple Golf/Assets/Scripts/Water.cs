using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour
{
    private Golf golf;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private ParticleSystem particle;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Golf>() != null)
        {
            golf = collision.gameObject.GetComponent<Golf>();
            LevelController._sumScore = golf.score;
            Destroy(collision.gameObject);
            audioSource.Play();
            particle.Play();
            StartCoroutine(waiter());
        }
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
