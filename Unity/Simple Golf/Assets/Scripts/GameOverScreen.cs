
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text pointsText;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private LevelController levelController;

    public void Awake()
    {
        pointsText.text = LevelController._sumScore + " Points";
    }

    public void ExitButton()
    {
        audioSource.Play();
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(0.1f);
        Application.Quit();
    }
}
