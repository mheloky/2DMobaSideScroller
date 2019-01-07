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
        
    }

    // Update is called once per frame
    void Update()
    {
        /*  float TARGET_WIDTH = 3000.0f;
          float TARGET_HEIGHT = 540.0f;
          int PIXELS_TO_UNITS = 30; // 1:1 ratio of pixels to units

          float desiredRatio = TARGET_WIDTH / TARGET_HEIGHT;
          float currentRatio = (float)Screen.width / (float)Screen.height;

          if (currentRatio >= desiredRatio)
          {
              // Our resolution has plenty of width, so we just need to use the height to determine the camera size
              Camera.main.orthographicSize = TARGET_HEIGHT / 4 / PIXELS_TO_UNITS;
          }
          else
          {
              // Our camera needs to zoom out further than just fitting in the height of the image.
              // Determine how much bigger it needs to be, then apply that to our original algorithm.
              float differenceInSize = desiredRatio / currentRatio;
              Camera.main.orthographicSize = TARGET_HEIGHT / 4 / PIXELS_TO_UNITS * differenceInSize;
          }*/

        /*if (Camera.main.orthographicSize != 5)
        {
            Camera.main.orthographicSize = 5;
        }*/

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
