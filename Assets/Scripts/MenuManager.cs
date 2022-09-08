using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public TextMeshProUGUI Score;

    private void Awake()
    {
        Instance = this;
    }

    public void setScore(int nscore)
    {
        Score.text = "Score: " + nscore;
    }
}
