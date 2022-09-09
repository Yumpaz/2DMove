using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerEndScene : MonoBehaviour
{
    public TextMeshProUGUI tscore;
    void Start()
    {
        int score = PlayerPrefs.GetInt("scorevalue");
        tscore.text = "Score = "+ score;
    }
    public void OnRestartClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}
