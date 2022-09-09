using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
}
