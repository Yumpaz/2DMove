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
    }

    public void SetScore(int Score)
    {
        tscore.text = "Score: " + Score;
    }

    public void SetCards(string[] inventory)
    {
        for (int i = 0; i <= 4; i++)
        {
            switch (i)
            {
                case 0:
                    switch (inventory[0])
                    {
                        case "rock":
                            card1.sprite = rock;
                            break;
                        case "paper":
                            card1.sprite = paper;
                            break;
                        case "scissors":
                            card1.sprite = scissors;
                            break;
                        case "empty":
                            card1.sprite = empty;
                            break;
                    }
                    break;
                case 1:
                    switch (inventory[1])
                    {
                        case "rock":
                            card2.sprite = rock;
                            break;
                        case "paper":
                            card2.sprite = paper;
                            break;
                        case "scissors":
                            card2.sprite = scissors;
                            break;
                        case "empty":
                            card2.sprite = empty;
                            break;
                    }
                    break;
                case 2:
                    switch (inventory[2])
                    {
                        case "rock":
                            card3.sprite = rock;
                            break;
                        case "paper":
                            card3.sprite = paper;
                            break;
                        case "scissors":
                            card3.sprite = scissors;
                            break;
                        case "empty":
                            card3.sprite = empty;
                            break;
                    }
                    break;
                case 3:
                    switch (inventory[3])
                    {
                        case "rock":
                            card4.sprite = rock;
                            break;
                        case "paper":
                            card4.sprite = paper;
                            break;
                        case "scissors":
                            card4.sprite = scissors;
                            break;
                        case "empty":
                            card4.sprite = empty;
                            break;
                    }
                    break;
                case 4:
                    switch (inventory[4])
                    {
                        case "rock":
                            card5.sprite = rock;
                            break;
                        case "paper":
                            card5.sprite = paper;
                            break;
                        case "scissors":
                            card5.sprite = scissors;
                            break;
                        case "empty":
                            card5.sprite = empty;
                            break;
                    }
                    break;
            }
        }
    }
}
