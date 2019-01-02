﻿using Assets._2DPlatformer.Scripts.BaseEngine.GameStructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Player thePlayer;
    public GameObject spawnerPositionTeam1;
    public GameObject spawnerPositionTeam2;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnLevelWasLoaded(int level)
    {
        var players = GameRoomStatus.GetPlayers();
        for (int i = 0; i < players.Count; i++)
        {
            var networkPlayer = players[i];
            var physicalPlayer = Instantiate(thePlayer);
            physicalPlayer.SetPlayer(networkPlayer);
            physicalPlayer.SetActive(true);
            if (networkPlayer.GetTeamID() == 0)
            {
                physicalPlayer.transform.position = spawnerPositionTeam1.transform.position;
            }

            if (networkPlayer.GetTeamID() == 1)
            {
                physicalPlayer.transform.position = spawnerPositionTeam2.transform.position;
            }
        }
    }
}