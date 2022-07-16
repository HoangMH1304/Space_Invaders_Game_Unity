using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAlien : MonoBehaviour
{
    public GameObject[] aliensType;
    public Transform parent;
    private const int ALIEN_HEIGHT = 4;
    private const int ALIEN_WIDTH = 5;
    [SerializeField]
    private int countAliens = 25;
    int[] alienIndex;
    private void Start()
    {
        Spawn();
    }
    void Spawn()
    {
        alienIndex = GetAlienType();
        for (int col = 0; col < 5; col++)
        {
            for (int row = 0; row <= col; row++)
            {
                // if (ChooseOrNot() == 1)
                // {
                CreateAlien(col, row);
                // }

            }
        }
    }

    private void CreateAlien(int col, int row)
    {
        Vector2 pos = new Vector2(ALIEN_HEIGHT * col, ALIEN_WIDTH * row);
        var alien = Instantiate(aliensType[alienIndex[5 * col + row]]);
        alien.transform.SetParent(parent);
        alien.transform.localPosition = pos;
    }

    private int[] GetAlienType()
    {
        int[] alienIndex = new int[25];
        for (int i = 0; i < countAliens; i++)
        {
            alienIndex[i] = Random.Range(0, 3);
        }
        return alienIndex;
    }

    private int ChooseOrNot()
    {
        return Random.Range(1, 100) % 2;
    }
}
