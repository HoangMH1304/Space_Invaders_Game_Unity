using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlienManager : MonoBehaviour
{
    public GameObject[] aliensType;
    public Transform parent;
    private const int ALIEN_HEIGHT = 4;
    private const int ALIEN_WIDTH = 5;
    private const int WAVES = 3;

    [SerializeField]
    private List<TextAsset> datas;
    [SerializeField]
    private int numRow = 5;
    [SerializeField]
    private int numCol = 5;
    int[,] alienMatrix = new int[5, 5];
    public Ship[,] alienInMatrix = new Ship[5, 5];
    char[] ignoreChar = { ' ', '\n' };
    private ChangeScene changeScene;
    private UIHandler uIHandler;
    private Player player;
    [SerializeField]
    public List<Ship> aliens;
    [SerializeField]
    private int wave;
    public UnityEvent<int> OnCall = new UnityEvent<int>();


    private void Start()
    {
        Debug.Log("Blue: 1");
        Debug.Log("Orange: 2");
        Debug.Log("Green: 3");
        Debug.Log("Yellow: 4");
        aliens = new List<Ship>();
        Init();
        GetReference();
        SpawnAlien();
        OnCall?.Invoke(wave);
    }

    private void Init()
    {
        wave = 1;
        InitMatrix();
    }
    private void GetReference()
    {
        changeScene = FindObjectOfType<ChangeScene>();
        uIHandler = FindObjectOfType<UIHandler>();
        player = GameObject.Find("SpaceShip").GetComponent<Player>();
    }

    public void DestroyAliens()                 //Destroy Button
    {
        // foreach (var enemy in aliens)
        // {
        //     enemy.Die();
        // }
        // for (int i = aliens.Count - 1; i >= 0; i--)
        // {
        //     aliens[i].Die();
        // }

        for (int i = 0; i < aliens.Count;)
        {
            aliens[i].Die();
        }
    }

    public void DamageAliens()                   // -1 Button
    {
        for (int i = aliens.Count - 1; i >= 0; i--)
        {
            aliens[i].TakeDamage(1);
        }
    }
    private void InitMatrix()
    {
        var readFile = datas[wave - 1].text;
        string[] numText = readFile.Split(ignoreChar);
        for (int i = 0; i < numRow; i++)
        {
            for (int j = 0; j < numCol; j++)
            {
                alienMatrix[i, j] = int.Parse(numText[i * 5 + j]);
            }
        }
    }

    void SpawnAlien()
    {
        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                SpawnAlien(row, col);
            }
        }
    }

    IEnumerator SpawnAliensCoroutine()
    {
        yield return new WaitForSeconds(1);
        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                SpawnAlien(row, col);
            }
        }
    }

    private void SpawnAlien(int row, int col)
    {
        var alien = CreateAlien(col, row);
        if (alien != null)
        {
            alien.OnDeath.AddListener(OnAlienDeath);
            aliens.Add(alien);
            alienInMatrix[row, col] = alien;
        }
    }

    public Ship GetAlienInMatrix(int row, int col)
    {
        if (alienMatrix[row, col] != -1) return alienInMatrix[row, col];
        return null;
    }

    private void OnAlienDeath(Ship alien)
    {
        aliens.Remove(alien);
        if (IsClearWave())
        {
            wave++;
            InitMatrix();
            OnCall?.Invoke(wave);
            StartCoroutine(SpawnAliensCoroutine());
        }
        else if (IsWin())
        {
            EndLevel();
            uIHandler.IncreaseHealth();
            GameManager.Instance.SetResultState(true);
        }
    }

    private void EndLevel()
    {
        changeScene.ChangeNextScene();
    }

    private bool IsWin()
    {
        return aliens.Count <= 0 && wave == WAVES;
    }

    private bool IsClearWave()
    {
        return aliens.Count <= 0 && wave < WAVES;
    }

    public Ship CreateAlien(int col, int row)
    {
        if (alienMatrix[row, col] != -1)
        {
            Vector2 pos = new Vector2(ALIEN_HEIGHT * col, ALIEN_WIDTH * row);
            var alien = Instantiate(aliensType[alienMatrix[row, col]]);
            alien.transform.SetParent(parent);
            alien.transform.localPosition = pos;
            Ship ship = alien.GetComponent<Ship>();
            ship.SetHealth(alienMatrix[row, col] + 1);
            ship.SetCoordinate(new Vector2(row, col));
            return ship;
        }
        return null;
    }
}