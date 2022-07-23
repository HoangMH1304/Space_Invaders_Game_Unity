using System;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    private GameState gameState;
    private UIHandler uIHandler;
    private TurnUpDownVolume changeVolume;
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
        // changeVolume = FindObjectOfType<TurnUpDownVolume>();
        // audioSourceMusic = GameObject.Find("Music(Clone)").GetComponent<AudioSource>();
        // audioSourceSFX = GameObject.Find("SoundManager").GetComponent<AudioSource>();
    }

    public void InitData()
    {
        gameState = new GameState();
        gameState.level = 1;
        gameState.playerHealth = 3;
        gameState.score = 0;
        gameState.result = "";
        gameState.IsWin = false;
        // gameState.volumeMusic = 0.5f;
        // gameState.volumeSFX = 0.5f;
        // gameState.volumeMusic = audioSourceMusic.volume;
        // gameState.volumeSFX = audioSourceSFX.volume;
    }

    // //getter, setter music
    // public float GetVolumeMusic()
    // {
    //     return gameState.volumeMusic;
    // }

    // public void SetVolumeMusic(float x)
    // {
    //     Debug.Log($"SetVolumeMusic: {x}");
    //     gameState.volumeMusic = x;
    //     audioSourceMusic.volume = x;
    // }

    // //getter, setter sfx
    // public float GetVolumeSFX()
    // {
    //     return gameState.volumeSFX;
    // }

    // public void SetVolumeSFX(float x)
    // {
    //     gameState.volumeSFX = x;
    //     audioSourceSFX.volume = x;
    // }


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