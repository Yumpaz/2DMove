using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    private GameState _gameState = GameState.start;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateGameState(GameState gameState)
    {
        _gameState = gameState;
    }

    void Update()
    {
        switch (_gameState)
        {
            case GameState.start:
                MenuManager.Instance.SetScore(0);
                break;
            case GameState.play:
                break;
            case GameState.end:
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
