using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    private int scorevalue = 0;
    private GameState _gameState = GameState.start;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateGameState(GameState gameState)
    {
        _gameState = gameState;
    }

    public void increaseScore()
    {
        scorevalue++;
    }

    void Update()
    {
        switch (_gameState)
        {
            case GameState.start:
                scorevalue = 0;
                MenuManager.Instance.SetScore(scorevalue);
                UpdateGameState(GameState.play);
                break;
            case GameState.play:
                MenuManager.Instance.SetScore(scorevalue);
                if (scorevalue == 5)
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

    public enum GameState
    {
        start,
        play,
        end
    }
}
