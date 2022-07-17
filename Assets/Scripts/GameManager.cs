using System;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    private GameState gameState;
    private UIHandler uIHandler;

    protected override void Awake()
    {
        base.Awake();
        Init();

    }

    private void Init()
    {
        InitData();
        GetReferences();
    }

    private void GetReferences()
    {
        uIHandler = FindObjectOfType<UIHandler>();
    }

    private void InitData()
    {
        gameState = new GameState();
        gameState.level = 1;
        gameState.playerHealth = 3;
        gameState.score = 0;
    }

    public void AddScore(int score)
    {
        gameState.score += score;
        uIHandler.UpdateScore();
    }

    public int GetSpaceShipHealth()
    {
        return gameState.playerHealth;
    }
}