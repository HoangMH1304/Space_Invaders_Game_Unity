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
    private TextMeshProUGUI musicVolumeText;
    private TextMeshProUGUI sfxVolumeText;
    private Slider sliderMusic;
    private Slider sliderSFX;
    private TurnUpDownVolume changeVolume;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        changeVolume = GameObject.Find("SoundManager").GetComponent<TurnUpDownVolume>();
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        changeVolume.UpdateMusicSFXValue();
        sliderMusic = GameObject.Find("SliderMusic").GetComponent<Slider>();
        sliderSFX = GameObject.Find("SliderSFX").GetComponent<Slider>();
        UpdateVolumeMusic(gameManager.GetVolumeMusic());
        UpdateVolumeSFX(gameManager.GetVolumeSFX());
        sliderMusic.value = gameManager.GetVolumeMusic();
        sliderSFX.value = gameManager.GetVolumeSFX();
    }



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

    public void UpdateVolumeMusic(float value)
    {
        int intergerValue = (int)(value * 100);
        var textUI = GameObject.Find("MusicText").GetComponent<TextMeshProUGUI>();
        textUI.text = "Music: " + intergerValue.ToString();
    }

    public void UpdateVolumeSFX(float value)
    {
        int intergerValue = (int)(value * 100);
        var textUI = GameObject.Find("SFXText").GetComponent<TextMeshProUGUI>();
        textUI.text = "SFX: " + intergerValue.ToString();
    }
}
