using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeGuyAI : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float mimicDelay;
    [SerializeField] private float followSpeed;
    [SerializeField] private float _difficultyScaler;

    [SerializeField] private GameManager gameManager;

    private Queue<Vector3> playerPositions = new Queue<Vector3>();
    private Queue<float> timestamps = new Queue<float>();
    private float lastMoveTime;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        followSpeed = followSpeed + (float)(_difficultyScaler * gameManager.Score);
        if (Time.time - lastMoveTime >= 0.1f)
        {
            playerPositions.Enqueue(playerTransform.position);
            timestamps.Enqueue(Time.time);
            lastMoveTime = Time.time;
        }

        if (playerPositions.Count > 0 && Time.time - timestamps.Peek() >= mimicDelay)
        {
            Vector3 mimicPosition = playerPositions.Dequeue();
            timestamps.Dequeue();

            transform.position = Vector3.MoveTowards(transform.position, mimicPosition, followSpeed * Time.deltaTime);
        }
    }
}
