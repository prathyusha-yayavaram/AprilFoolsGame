using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    private Vector3 playerStartPos;
    private List<int> playerCheckpointBlockAmounts;

    private void Awake()
    {
        instance = this;
        playerCheckpointBlockAmounts = new List<int>();
        playerStartPos = player.transform.position;
    }

    private void Start()
    {
        playerCheckpointBlockAmounts = ClickPlaceBlock.instance.blockAmounts;
    }

    public void SetNewCheckpoint(Vector3 pos)
    {
        playerStartPos = pos;
        playerCheckpointBlockAmounts = ClickPlaceBlock.instance.blockAmounts;
    }
    public void RespawnAtCheckpoint()
    {
        player.transform.position = playerStartPos;
        ClickPlaceBlock.instance.blockAmounts = playerCheckpointBlockAmounts;
    }
}
