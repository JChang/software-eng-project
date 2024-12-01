using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public const int DEFAULT_HEALTH = 3;
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
    public CoinSpawner CoinSpawner;

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
    }

    public void DecreaseHealth(int amount)
    {
        Health -= amount;
        UIManager.UpdateHealth(Health);
    }
}