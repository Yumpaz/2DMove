using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    private int scorevalue = 0;
    private GameState _gameState = GameState.start;
    string[] inventory = new string[5];
    public Sprite paper;
    public Sprite scissors;
    public Sprite rock;

    private void Awake()
    {
        Instance = this;
    }

    public bool FullInventory()
    {
        if (inventory[4] != "empty")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void UpdateGameState(GameState gameState)
    {
        _gameState = gameState;
    }

    public void increaseScore()
    {
        scorevalue++;
    }

    private void Update()
    {
        switch (_gameState)
        {
            case GameState.start:
                scorevalue = 0;
                MenuManager.Instance.SetScore(scorevalue);
                initialinventory();
                MenuManager.Instance.SetCards(inventory);
                UpdateGameState(GameState.play);
                break;
            case GameState.play:
                MenuManager.Instance.SetScore(scorevalue);
                if (Input.GetButtonDown("Fire3"))
                {
                    ImageChange();
                    MenuManager.Instance.SetCards(inventory);
                }
                if (scorevalue == 25)
                {
                    UpdateGameState(GameState.end);
                }
                break;
            case GameState.end:
                PlayerPrefs.SetInt("scorevalue", scorevalue);
                SceneManager.LoadScene("EndScene");
                break;
        }
    }

    private void initialinventory()
    {
        inventory[0] = "rock";
        inventory[1] = "paper";
        inventory[2] = "scissors";
        inventory[3] = "empty";
        inventory[4] = "empty";
    }

    private void addorder(string addeditem)
    {
        if(inventory[0] == "empty")
        {
            inventory[0] = addeditem;
        }
        else
        {
            if (inventory[0] != "empty" && inventory[1] == "empty")
            {
                inventory[1] = addeditem;
            }
            else
            {
                if (inventory[0] != "empty" && inventory[1] != "empty" && inventory[2] == "empty")
                {
                    inventory[2] = addeditem;
                }
                else
                {
                    if (inventory[0] != "empty" && inventory[1] != "empty" && inventory[2] != "empty" && inventory[3] == "empty")
                    {
                        inventory[3] = addeditem;
                    }
                    else
                    {
                        if (inventory[0] != "empty" && inventory[1] != "empty" && inventory[2] != "empty" && inventory[3] != "empty" && inventory[4] == "empty")
                        {
                            inventory[4] = addeditem;
                        }
                    }
                }
            }
        }
    }

    public void ImageChange()
    {
        string temp;

        if (inventory[0] == "empty" || inventory[0] != "empty" && inventory[1] == "empty" && inventory[2] == "empty" && inventory[3] == "empty" && inventory[4] == "empty")
        {

        }
        else
        {
            if (inventory[0] != "empty" && inventory[1] != "empty" && inventory[2] == "empty" && inventory[3] == "empty" && inventory[4] == "empty")
            {
                temp = inventory[0];
                inventory[0] = inventory[1];
                inventory[1] = temp;
            }
            else
            {
                if (inventory[0] != "empty" && inventory[1] != "empty" && inventory[2] != "empty" && inventory[3] == "empty" && inventory[4] == "empty")
                {
                    temp = inventory[0];
                    inventory[0] = inventory[1];
                    inventory[1] = inventory[2];
                    inventory[2] = temp;
                }
                else
                {
                    if (inventory[0] != "empty" && inventory[1] != "empty" && inventory[2] != "empty" && inventory[3] != "empty" && inventory[4] == "empty")
                    {
                        temp = inventory[0];
                        inventory[0] = inventory[1];
                        inventory[1] = inventory[2];
                        inventory[2] = inventory[3];
                        inventory[3] = temp;
                    }
                    else
                    {
                        if (inventory[0] != "empty" && inventory[1] != "empty" && inventory[2] != "empty" && inventory[3] != "empty" && inventory[4] != "empty")
                        {
                            temp = inventory[0];
                            inventory[0] = inventory[1];
                            inventory[1] = inventory[2];
                            inventory[2] = inventory[3];
                            inventory[3] = inventory[4];
                            inventory[4] = temp;
                        }
                    }
                }
            }
        }
    }

    public void AddInventory(string item)
    {
        string addeditem;
        if(item == "rockskill")
        {
            addeditem = "rock";
            addorder(addeditem);
        }
        else
        {
            if(item == "paperskill")
            {
                addeditem = "paper";
                addorder(addeditem);
            }
            else
            {
                if(item == "scissorsskill")
                {
                    addeditem = "scissors";
                    addorder(addeditem);
                }
            }
        }
        MenuManager.Instance.SetCards(inventory);
    }

    public enum GameState
    {
        start,
        play,
        end
    }
}
