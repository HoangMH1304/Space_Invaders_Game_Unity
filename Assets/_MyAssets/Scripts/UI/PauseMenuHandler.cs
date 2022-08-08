using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenuHandler : MonoBehaviour
{
    private const int FIRST_SCENE = 0;
    public GameObject pauseMenu;
    private GameManager gameManager;
    private SoundManager soundManager;
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
        UpdateMusicValueText(SoundManager.Instance.GetVolumeMusic());
        UpdateSFXValueText(SoundManager.Instance.GetVolumeSFX());
        var soundSliderSaver = GameObject.Find("Canvas").GetComponent<MusicSliderSaver>();
        soundSliderSaver.GetMusicSliderChange();
        soundSliderSaver.GetSFXSliderChange();
    }

    public void Resume()    //On Click
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void Restart()   //On Click
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(FIRST_SCENE);
    }

    public void QuitGame()  //On Click
    {
        Application.Quit();
    }

    public void TurnUpMusic(float x)    //On Click
    {
        SoundManager.Instance.SetVolumeMusic(x);
        PlayerPrefs.SetFloat("Music", x);
        PlayerPrefs.Save();
    }

    public void TurnUpSFX(float x)  //On Click
    {
        SoundManager.Instance.SetVolumeSFX(x);
        PlayerPrefs.SetFloat("SFX", x);
        PlayerPrefs.Save();
    }

    public void UpdateMusicValueText(float t)   //On Click
    {
        var textMusicValue = GameObject.Find("MusicText").GetComponent<TextMeshProUGUI>();
        int value = (int)(t * 100);
        textMusicValue.text = "Music: " + value.ToString();
    }

    public void UpdateSFXValueText(float t) //On Click
    {
        var textSFXValue = GameObject.Find("SFXText").GetComponent<TextMeshProUGUI>();
        int value = (int)(t * 100);
        textSFXValue.text = "SFX: " + value.ToString();
    }
}