using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public CoinData CoinData;
    public GameObject CoinPrefab;
    public MazeGenerator MazeGenerator;
    public GameManager GameManager;

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

    public Vector2 GetRandomPositionInMaze()
    {
        int randomX = Random.Range(0, MazeGenerator._mazeWidth);
        int randomY = Random.Range(0, MazeGenerator._mazeLength);
        MazeCell randomCell = MazeGenerator._mazeGrid[randomX, randomY];

        Vector2 cellCenter = randomCell.transform.position;

        return cellCenter;
    }
}