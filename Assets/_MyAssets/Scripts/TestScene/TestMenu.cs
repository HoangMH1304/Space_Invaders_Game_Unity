using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;
    public void OnClick()
    {
        if (menu.activeSelf == false)
        {
            Time.timeScale = 0;
            menu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            menu.SetActive(false);
        }
    }
}
