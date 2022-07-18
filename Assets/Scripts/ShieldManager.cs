using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    [SerializeField]
    private GameObject block;
    [SerializeField]
    private TextAsset data;
    [SerializeField]
    private Transform parent;
    const float BLOCK_HEIGHT = 2.0f;
    const float BLOCK_WIDTH = 2.0f;
    const int NUMBER_OF_SHIELD = 3;
    int[,] shield;
    int numberOfRow;
    int numberOfCol;
    int distanceBetweenShield;
    char[] ignoreChar = { ' ', '\n' };
    private void Start()
    {
        Init();
        CreateShields();
    }

    private void CreateShields()
    {
        for (int i = 0; i < NUMBER_OF_SHIELD; i++)
        {
            Spawn(i);
        }
    }

    void Init()
    {
        var readFile = data.text;
        string[] numText = readFile.Split(ignoreChar);
        numberOfRow = int.Parse(numText[0]);
        numberOfCol = int.Parse(numText[1]);
        distanceBetweenShield = int.Parse(numText[2]);
        shield = Convert(numText);
    }

    int[,] Convert(string[] numText)
    {
        int[,] shield = new int[numberOfRow, numberOfCol];
        for (int row = 0; row < numberOfRow; row++)
        {
            for (int col = 0; col < numberOfCol; col++)
            {
                shield[row, col] = int.Parse(numText[3 + row * numberOfCol + col]);
            }
        }
        return shield;
    }

    void Spawn(int index)
    {
        for (int row = 0; row < numberOfRow; row++)
        {
            for (int col = 0; col < numberOfCol; col++)
            {
                if (shield[row, col] == 1)
                {
                    Vector2 pos = new Vector2(BLOCK_HEIGHT * col, BLOCK_WIDTH * row);
                    var shield = Instantiate(block);
                    shield.transform.SetParent(parent);
                    shield.transform.localPosition = pos + new Vector2(BLOCK_HEIGHT * (numberOfCol + distanceBetweenShield), 0) * index;
                }
            }
        }
    }
}