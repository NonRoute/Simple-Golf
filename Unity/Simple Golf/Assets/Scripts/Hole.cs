using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hole : MonoBehaviour
{
    private Golf golf;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private LevelController levelController;
    [SerializeField]
    private ParticleSystem particle;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        golf = collision.gameObject.GetComponent<Golf>();
        if (golf != null)
        {
            Destroy(collision.gameObject);
            audioSource.Play();
            particle.Play();
            StartCoroutine(waiter());
        }
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1);
        levelController.nextLevel(golf.score);
    }

}
