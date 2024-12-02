using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const int DEFAULT_HEALTH = 6;
    public static GameManager Instance;

    public int Score = 0;
    private int _health = DEFAULT_HEALTH;

    public int Health {
        get {
            return _health;
        }
        set {
            _health = value;
            if (value <= 0) {
                EndGame.TriggerEndGame();
            }
        }
    }

    public UIManager UIManager;
    public ItemSpawner ItemSpawner;
    public EnemySpawner EnemySpawner;

    // [SerializeField] private int _spawnRate;

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
        ItemSpawner = FindObjectOfType<ItemSpawner>();
        EnemySpawner = FindObjectOfType<EnemySpawner>();

        UIManager.UpdateHealth(Health);
        UIManager.UpdateScore(Score);

        StartCoroutine(SpawnCoinsAfterDelay());
    }

    IEnumerator SpawnCoinsAfterDelay()
    {
        yield return new WaitForSeconds(0.1f);
        ItemSpawner.SpawnCoins(Score);
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
