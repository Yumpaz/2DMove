using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public TextMeshProUGUI tscore;
    private void Awake()
    {
        Instance = this;
    }

    public void SetScore(int Score)
    {
        tscore.text = "Score: " + Score;
    }

    public void OnRestartClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}
