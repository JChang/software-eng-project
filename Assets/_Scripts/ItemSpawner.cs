using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public CoinData CoinData;
    public MazeGenerator MazeGenerator;
    public GameManager GameManager;

    public GameObject CoinPrefab;
    public GameObject TeleporterPrefab;

    [SerializeField] private int spawnInterval;
    [SerializeField] private int teleportSpawnInterval;

    void Start()
    {
        Invoke("TrySpawnCoin", spawnInterval);
        Invoke("TrySpawnTeleporter", teleportSpawnInterval);
    }

    void TrySpawnCoin()
    {
        if (Random.value <= 0.5f)
        {
            SpawnCoins(GameManager.Score);
        }

        Invoke("TrySpawnCoin", spawnInterval);
    }

    public void SpawnCoins(int playerScore)
    {
        int maxCoins = 10;
        int numCoins = Mathf.Min(Random.Range(1, playerScore / 2 + 1), maxCoins);

        for (int i = 0; i < numCoins; i++)
        {
            Vector2 randomPosition = GetRandomPositionInMaze();
            int coinValue = Random.Range(CoinData.MinValue, CoinData.MaxValue + 1);

            GameObject coin = Instantiate(CoinPrefab, randomPosition, Quaternion.identity);
            coin.GetComponent<Coin>().Value = coinValue;
        }
    }

    void TrySpawnTeleporter()
    {
        if (Random.value <= 0.5f)
        {
            SpawnTeleporter();
        }

        Invoke("TrySpawnTeleporter", teleportSpawnInterval);
    }

    public void SpawnTeleporter()
    {
        Vector2 randomPosition = GetRandomPositionInMaze();
        Instantiate(TeleporterPrefab, randomPosition, Quaternion.identity);
    }

    public Vector2 GetRandomPositionInMaze()
    {
        MazeGenerator = FindObjectOfType<MazeGenerator>();

        int randomX = Random.Range(0, MazeGenerator._mazeWidth);
        int randomY = Random.Range(0, MazeGenerator._mazeLength);
        MazeCell randomCell = MazeGenerator._mazeGrid[randomX, randomY];

        if (randomCell == null)
        {
            return Vector2.zero;
        }

        return randomCell.transform.position;
    }
}