
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    public void PlayButton()
    {
        audioSource.Play();
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Level1");
    }
}
