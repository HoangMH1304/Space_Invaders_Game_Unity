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
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void ChangeNextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0) gameManager.IncreaseLevel();
        else if (gameManager != null && SceneManager.GetActiveScene().buildIndex == 0) gameManager.InitData();
        Invoke("OpenNextScene", secTillSceneLoad);
    }

    public void ChangeLastScene()
    {
        gameManager.SetResult("You Lose!");
        sceneIndex = LAST_SCENE;
        Invoke("OpenNextScene", secTillSceneLoad);
    }
    void OpenNextScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
