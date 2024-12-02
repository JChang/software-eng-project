using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceToObj : MonoBehaviour
{
    private GameObject player;
    private float distanceToPlayer;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {

        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log("Distance to player: " + distanceToPlayer);
    }
}