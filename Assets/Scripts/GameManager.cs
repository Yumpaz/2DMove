using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private GameState _gameState = GameState.start;
    private int score;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateGameState(GameState gameState)
    {
        _gameState = gameState;
    }

    public void IncreaseScore()
    {
        score++;
    }

    void Update()
    {
        switch (_gameState)
        {
            case GameState.start:
                score = 0;
                MenuManager.Instance.setScore(score);
                UpdateGameState(GameState.play);
                break;

            case GameState.play:
                MenuManager.Instance.setScore(score);
                if (score == 20)
                {
                    UpdateGameState(GameState.end);
                }
                break;

            case GameState.end:
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
