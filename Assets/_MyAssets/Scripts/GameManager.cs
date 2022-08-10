using System;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    private GameState gameState;
    private UIHandler uIHandler;
    private AudioSource audioSourceMusic;
    private AudioSource audioSourceSFX;

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
        gameState.score = 8000;
        gameState.result = "";
        gameState.IsWin = false;
    }

    public void SetResultState(bool logic)
    {
        gameState.IsWin = logic;
    }

    public bool GetResultState()
    {
        return gameState.IsWin;
    }
    public void IncreaseLevel()
    {
        gameState.level++;
    }

    public int GetLevel()
    {
        return gameState.level;
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


    public int GetSpaceShipHealth()
    {
        return gameState.playerHealth;
    }

    public void UpdatePlayerHealth(int health)
    {
        gameState.playerHealth = health;
    }
}