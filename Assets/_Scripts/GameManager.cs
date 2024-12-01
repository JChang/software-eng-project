using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Score = 0;
    public int Health = 3;

    public UIManager UIManager;
    public CoinSpawner CoinSpawner;
    public EnemySpawner EnemySpawner;

    [SerializeField] private int spawnRate;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        UIManager = FindObjectOfType<UIManager>();
        CoinSpawner = FindObjectOfType<CoinSpawner>();
        EnemySpawner = FindObjectOfType<EnemySpawner>();

        UIManager.UpdateHealth(Health);
        UIManager.UpdateScore(Score);

        StartCoroutine(SpawnCoinsAfterDelay());
    }

    IEnumerator SpawnCoinsAfterDelay()
    {
        yield return new WaitForSeconds(0.1f);
        CoinSpawner.SpawnCoins(Score);
    }

    public void AddScore(int amount)
    {
        Score += amount;
        UIManager.UpdateScore(Score);

        /*while (Score >= spawnRate)
        {
            SpawnEnemy();
            spawnRate += (int)((spawnRate ^ 2) * 0.5);
        }*/
    }

    public void DecreaseHealth(int amount)
    {
        Health -= amount;
        UIManager.UpdateHealth(Health);
    }

    /*private void SpawnEnemy()
    {
        EnemySpawner.SpawnRandomEnemy();
    }*/
}
