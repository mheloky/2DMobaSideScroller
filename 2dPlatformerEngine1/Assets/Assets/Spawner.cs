using Assets._2DPlatformer.Scripts.BaseEngine.GameStructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Player thePlayer;
    public GameObject spawnerPositionTeam1;
    public GameObject spawnerPositionTeam2;
    public Camera deadZoneCamera;
    // Start is called before the first frame update
    void Start()
    {
        deadZoneCamera.orthographicSize =    13;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnLevelWasLoaded(int level)
    {
        var players = GameRoomStatus.GetPlayersSouls();
        for (int i = 0; i < players.Count; i++)
        {
            var networkPlayer = players[i];
            var physicalPlayer = Instantiate(thePlayer);
            physicalPlayer.SetPlayer(networkPlayer);
            physicalPlayer.SetActive(true);
            if (networkPlayer.GetTeamID() == 0)
            {
                physicalPlayer.transform.position = new Vector3(spawnerPositionTeam1.transform.position.x, spawnerPositionTeam1.transform.position.y);
            }

            if (networkPlayer.GetTeamID() == 1)
            {
                physicalPlayer.transform.position = new Vector3(spawnerPositionTeam2.transform.position.x, spawnerPositionTeam2.transform.position.y);
            }

            GameRoomStatus.AddPhysicalPlayer(networkPlayer.GetClientID(), physicalPlayer);
        }
    }
}
