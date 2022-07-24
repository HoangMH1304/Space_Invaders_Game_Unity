using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private const int LAST_SCENE = 4;
    private const int OPENING_SCENE = 0;
    public int sceneIndex;
    [SerializeField]
    private int secTillSceneLoad = 3;
    private GameManager gameManager;
    private GameState gameState;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void ChangeNextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0) GameManager.Instance.IncreaseLevel();
        else if (gameManager != null && SceneManager.GetActiveScene().buildIndex == 0) GameManager.Instance.InitData();
        Invoke("OpenNextScene", secTillSceneLoad);
    }

    public void ChangeLastScene()
    {
        GameManager.Instance.SetResultState(false);
        sceneIndex = LAST_SCENE;
        Invoke("OpenNextScene", 1.5f);
    }
    void OpenNextScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
