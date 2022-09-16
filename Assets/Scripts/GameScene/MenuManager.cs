using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public TextMeshProUGUI tscore;
    public Image card1;
    public Image card2;
    public Image card3;
    public Image card4;
    public Image card5;
    public Sprite rock;
    public Sprite paper;
    public Sprite scissors;
    public Sprite empty;
    private void Awake()
    {
        Instance = this;
        card1.sprite = rock;
        card2.sprite = paper;
        card3.sprite = scissors;
        card4.sprite = empty;
        card5.sprite = empty;
    }

    public void SetScore(int Score)
    {
        tscore.text = "Score: " + Score;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            imageChange();
        }
    }

    public void imageChange()
    {
        Sprite temp;
        temp= card1.sprite;
        card1.sprite = card2.sprite;
        card2.sprite = card3.sprite;
        card3.sprite = temp;
    }
}
