using System;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    private GameState gameState;
    private UIHandler uIHandler;
    private TurnUpDownVolume changeVolume;

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
        changeVolume = GameObject.Find("SoundManager").GetComponent<TurnUpDownVolume>();
    }

    public void InitData()
    {
        gameState = new GameState();
        gameState.level = 1;
        gameState.playerHealth = 3;
        gameState.score = 0;
        gameState.result = "";
        gameState.volumeMusic = 0;
        gameState.volumeSFX = 0;
        // changeVolume.UpdateMusicSFXValue();
    }

    public float GetVolumeMusic()
    {
        return gameState.volumeMusic;
    }

    public void SetVolumeMusic(float x)
    {
        gameState.volumeMusic = x;
    }

    public float GetVolumeSFX()
    {
        return gameState.volumeSFX;
    }

    public void SetVolumeSFX(float x)
    {
        gameState.volumeSFX = x;
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