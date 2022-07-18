using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AlienManager : MonoBehaviour
{
    public GameObject[] aliensType;
    public Transform parent;
    private const int ALIEN_HEIGHT = 4;
    private const int ALIEN_WIDTH = 5;
    [SerializeField]
    private TextAsset data;
    [SerializeField]
    private int numRow = 5;
    [SerializeField]
    private int numCol = 5;
    int[,] alienMatrix = new int[5, 5];
    char[] ignoreChar = { ' ', '\n' };
    private ChangeScene changeScene;
    private GameManager gameManager;
    private Player player;
    [SerializeField]
    private List<Ship> aliens;

    private void Start()
    {
        aliens = new List<Ship>();
        InitMatrix();
        Spawn();
        changeScene = GameObject.Find("Main Camera").GetComponent<ChangeScene>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("SpaceShip").GetComponent<Player>();
    }

    public void DestroyAliens()
    {
        // foreach (var enemy in aliens)
        // {
        //     enemy.Die();
        // }
        for (int i = aliens.Count - 1; i >= 0; i--)
        {
            aliens[i].Die();
        }
    }
    private void InitMatrix()
    {
        var readFile = data.text;
        string[] numText = readFile.Split(ignoreChar);
        for (int i = 0; i < numRow; i++)
        {
            for (int j = 0; j < numCol; j++)
            {
                alienMatrix[i, j] = int.Parse(numText[i * 5 + j]);
            }
        }
    }

    void Spawn()
    {
        // alienIndex = GetAlienType();
        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                var alien = CreateAlien(col, row);
                if (alien != null)
                {
                    alien.OnDeath.AddListener(OnAlienDeath);
                    aliens.Add(alien);
                }
            }
        }
    }

    private void OnAlienDeath(Ship alien)
    {
        aliens.Remove(alien);
        if (IsWin())
        {
            EndLevel();
            gameManager.UpdatePlayerHealth(player.GetHealth());
        }
    }

    private void EndLevel()
    {
        changeScene.ChangeNextScene();
    }

    private bool IsWin()
    {
        return aliens.Count <= 0;
    }

    private Ship CreateAlien(int col, int row)
    {
        if (alienMatrix[row, col] != -1)
        {
            Vector2 pos = new Vector2(ALIEN_HEIGHT * col, ALIEN_WIDTH * row);
            var alien = Instantiate(aliensType[alienMatrix[row, col]]);
            alien.transform.SetParent(parent);
            alien.transform.localPosition = pos;
            return alien.GetComponent<Ship>();
        }
        return null;
    }


}
