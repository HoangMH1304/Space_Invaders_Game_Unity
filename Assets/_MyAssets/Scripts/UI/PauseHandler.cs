using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseHandler : MonoBehaviour
{
    public GameObject pauseMenu;
    private GameManager gameManager;
    private SoundManager soundManager;
    private TurnUpDownVolume changeVolume;
    private UIHandler uIHandler;
    // private MusicSliderSaver musicSliderSaver;
    // private MusicSliderSaver sfxSliderSaver;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        gameManager = FindObjectOfType<GameManager>();
        uIHandler = FindObjectOfType<UIHandler>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }



    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        VolumeHandler();
    }


    private void VolumeHandler()
    {
        float volumeMusicNow, volumeSFXNow;
        AdjustSound(out volumeMusicNow, out volumeSFXNow);
        var soundSliderSaver = GameObject.Find("Canvas").GetComponent<MusicSliderSaver>();
        soundSliderSaver.SetMusicSliderChange(volumeMusicNow);
        soundSliderSaver.SetSFXSliderChange(volumeSFXNow);
        soundSliderSaver.GetMusicSliderChange();
        soundSliderSaver.GetSFXSliderChange();

    }

    private void AdjustSound(out float volumeMusicNow, out float volumeSFXNow)
    {
        volumeMusicNow = soundManager.GetVolumeMusic();
        volumeSFXNow = soundManager.GetVolumeSFX();
        // uIHandler.UpdateUIVolumeMusic(volumeMusicNow);
        // uIHandler.UpdateUIVolumeSFX(volumeSFXNow);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}