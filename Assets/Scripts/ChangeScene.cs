using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int sceneIndex;
    [SerializeField]
    private int secTillSceneLoad = 3;


    public void ChangeNextScene()
    {
        Invoke("OpenNextScene", secTillSceneLoad);
    }

    public void ChangeLastScene()
    {
        sceneIndex = 5;
        Invoke("OpenNextScene", secTillSceneLoad);
    }
    void OpenNextScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
