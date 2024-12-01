using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> EnemyPrefabs;
    public MazeGenerator MazeGenerator;

    public List<GameObject> RequiredEntities;
    private Dictionary<GameObject, GameObject> SpecialEnemyMappings;

    private void Start()
    {
        SpecialEnemyMappings = new Dictionary<GameObject, GameObject>
        {
            { EnemyPrefabs[0], RequiredEntities[0] },
            { EnemyPrefabs[1], null },
            { EnemyPrefabs[2], null },
            { EnemyPrefabs[3], null },
            { EnemyPrefabs[4], null }
        };
    }

    public void SpawnRandomEnemy()
    {
        int randomIndex = Random.Range(0, EnemyPrefabs.Count);
        GameObject selectedEnemy = EnemyPrefabs[randomIndex];

        Vector2 randomPosition = GetRandomPositionInMaze();

        GameObject enemyInstance = Instantiate(selectedEnemy, randomPosition, Quaternion.identity);

        if (SpecialEnemyMappings.TryGetValue(selectedEnemy, out GameObject requiredEntity) && requiredEntity != null)
        {
            Vector2 offset = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            Vector2 requiredEntityPosition = randomPosition + offset;

            Instantiate(requiredEntity, requiredEntityPosition, Quaternion.identity);
        }
    }

    private Vector2 GetRandomPositionInMaze()
    {
        int randomX = Random.Range(0, MazeGenerator._mazeWidth);
        int randomY = Random.Range(0, MazeGenerator._mazeLength);
        MazeCell randomCell = MazeGenerator._mazeGrid[randomX, randomY];

        return randomCell.transform.position;
    }
}
