using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectDifficulty : MonoBehaviour
{
    private float difficulty;
    
    public void OnEasyClick()
    {
        difficulty = 1f;
        PlayerPrefs.SetFloat("difficulty", difficulty);
        SceneManager.LoadScene("Level1");
    }

    public void OnNormalClick()
    {
        difficulty = 2f;
        PlayerPrefs.SetFloat("difficulty", difficulty);
        SceneManager.LoadScene("Level1");
    }

    public void OnHardClick()
    {
        difficulty = 3f;
        PlayerPrefs.SetFloat("difficulty", difficulty);
        SceneManager.LoadScene("Level1");
    }
}
