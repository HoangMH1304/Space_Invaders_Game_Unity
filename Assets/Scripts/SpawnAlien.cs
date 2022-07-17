using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SpawnAlien : MonoBehaviour
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


    private void Start()
    {
        InitMatrix();
        Spawn();
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
                CreateAlien(row, col);

            }
        }
    }

    private void CreateAlien(int col, int row)
    {
        if (alienMatrix[row, col] != -1)
        {
            Vector2 pos = new Vector2(ALIEN_HEIGHT * col, ALIEN_WIDTH * row);
            var alien = Instantiate(aliensType[alienMatrix[row, col]]);
            alien.transform.SetParent(parent);
            alien.transform.localPosition = pos;
        }
    }
}
