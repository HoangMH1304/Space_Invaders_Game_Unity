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

    public void InitData()
    {
        gameState = new GameState();
        gameState.level = 1;
        gameState.playerHealth = 3;
        gameState.score = 0;
        gameState.result = "";
    }

    public void SetResult(string result)
    {
        gameState.result = result;
    }

    public string GetResult()
    {
        return gameState.result;
    }
    public void IncreaseLevel()
    {
        gameState.level++;
    }

    public int GetLevel()
    {
        return gameState.level;
    }

    public void SetLevel(int level)
    {
        gameState.level = level;
    }
    public void AddScore(int score)
    {
        gameState.score += score;
        uIHandler.UpdateValue("Score", gameState.score);
    }

    public int GetScore()
    {
        return gameState.score;
    }

    public void SetScore(int score)
    {
        gameState.score = score;
    }

    public int GetSpaceShipHealth()
    {
        return gameState.playerHealth;
    }

    public void UpdatePlayerHealth(int health)
    {
        gameState.playerHealth = health;
    }
}