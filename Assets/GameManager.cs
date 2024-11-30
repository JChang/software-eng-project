using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Score = 0;
    public int Health = 3;

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