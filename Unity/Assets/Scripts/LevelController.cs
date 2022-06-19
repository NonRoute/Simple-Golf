using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static int _sumScore = 5;
    private static int _nextLevelIndex = 1;
    private int lastLevel = 12;
    int[] scoreLevel = { 5, 4, 5, 4, 4, 4, 7, 7, 4, 4, 6, 4};

    public void nextLevel(int score)
    {
        _sumScore = score;
        if (_nextLevelIndex < scoreLevel.Length)
        {
            _sumScore += scoreLevel[_nextLevelIndex];
        }
        _nextLevelIndex++;
        if (_nextLevelIndex == lastLevel+1)
        { 
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            string nextLevelName = "Level" + _nextLevelIndex;
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
