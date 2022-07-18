using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private const int LOSE_SCENE = 5;
    private const int WIN_SCENE = 4;
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
        sceneIndex = LOSE_SCENE;
        Invoke("OpenNextScene", secTillSceneLoad);
    }
    void OpenNextScene()
    {
        Debug.Log(sceneIndex);
        Debug.Log(gameManager?.GetLevel());
        SceneManager.LoadScene(sceneIndex);
    }
}
