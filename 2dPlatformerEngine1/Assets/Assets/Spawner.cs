using Assets._2DPlatformer.Scripts.BaseEngine.GameStructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnerPositionTeam1;
    public GameObject spawnerPositionTeam2;

    // Start is called before the first frame update
    void Start()
    {
        var players = GameRoomStatus.GetPlayers();
        for (int i=0;i< players.Count; i++)
        {
            var networkPlayer = players[i];
            var physicalPlayer = Instantiate(new Player());
            physicalPlayer.SetPlayer(networkPlayer);

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
