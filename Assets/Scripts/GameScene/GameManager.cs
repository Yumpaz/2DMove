using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    private int scorevalue = 0, health;
    private float timer, timeBetweenFiring = 0.4f, difficulty;
    private GameState _gameState = GameState.start;
    string[] inventory = new string[5];
    public Sprite paper, scissors, rock;
    public string bullettype;
    private bool canFire;
    public Texture2D crosshair;
    public EnemySpawner Spawner;

    private void Awake()
    {
        Instance = this;
        Cursor.SetCursor(crosshair, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void initialHealth()
    {
        health = 3;
    }

    public void SpawnHealth()
    {
        Spawner.SpawnHealth();
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
                initialHealth();
                MenuManager.Instance.SetHealth(health);
                UpdateGameState(GameState.play);
                break;
            case GameState.play:
                MenuManager.Instance.SetScore(scorevalue);
                if (Input.GetButtonDown("Fire3"))//Cambio de carta
                {
                    ImageChange();
                    MenuManager.Instance.SetCards(inventory);
                }
                if (Input.GetButtonDown("Fire1"))
                {
                    ShootCard();
                    MenuManager.Instance.SetCards(inventory);
                }
                if (health == 0)
                {
                    UpdateGameState(GameState.end);
                }
                if (!canFire)
                {
                    timer += Time.deltaTime;
                    if (timer > timeBetweenFiring)
                    {
                        canFire = true;
                        timer = 0;
                    }
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
        bullettype = inventory[0];
    }

    public string Get1Inventory()
    {
        return inventory[0];
    }

    public string GetBulletType()
    {
        return bullettype;
    }

    private void addorder(string addeditem)//Función para saber donde agregar item recogido
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
        bullettype = inventory[0];
    }

    public void ShootCard()
    {
        bullettype = inventory[0];
        if (canFire)
        {
            for (int i = 0; i < 4; i++)
            {
                inventory[i] = inventory[i + 1];
            }
            inventory[4] = "empty";
            canFire = false;
        }
    }

    public void ImageChange()//Función ejecutada para cambiar la carta seleccionada
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
        bullettype = inventory[0];
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

    public void LostHealth()
    {
        if(health > 0)
        {
            health --;
        }
        MenuManager.Instance.SetHealth(health);
        ScreenShake.Instance.SetStart();
    }

    public void GainHealth()
    {
        if (health < 3)
        {
            health++;
        }
        MenuManager.Instance.SetHealth(health);
    }

    public int GetHealth()
    {
        return health;
    }

    public enum GameState
    {
        start,
        play,
        end
    }
}
