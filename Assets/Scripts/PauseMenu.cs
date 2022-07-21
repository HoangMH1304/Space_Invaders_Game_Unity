using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private GameManager gameManager;
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

    }



    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        AdjustVolume();
    }


    private void AdjustVolume()
    {
        float volumeMusicNow = gameManager.GetVolumeMusic();
        float volumeSFXNow = gameManager.GetVolumeSFX();
        // uIHandler.UpdateUIVolumeMusic(volumeMusicNow);
        // uIHandler.UpdateUIVolumeSFX(volumeSFXNow);
        var soundSliderSaver = GameObject.Find("Canvas").GetComponent<MusicSliderSaver>();
        soundSliderSaver.SetMusicSliderChange(volumeMusicNow);
        soundSliderSaver.SetSFXSliderChange(volumeSFXNow);
        soundSliderSaver.GetMusicSliderChange();
        soundSliderSaver.GetSFXSliderChange();

    }


    //
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }



    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
