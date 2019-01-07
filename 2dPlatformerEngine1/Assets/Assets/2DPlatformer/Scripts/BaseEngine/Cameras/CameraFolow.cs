using Assets._2DPlatformer.Scripts.BaseEngine.GameStructure;
using Assets._2DPlatformer.Scripts.BaseEngine.Level;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    Player TheMainPlayer;
    public GrassPlainsLevel TheLevel;

    // Start is called before the first frame update
    void Start()
    {
       //this.GetComponent<Camera>().orthographicSize = 15;
       TheMainPlayer = GameRoomStatus.GetThisMainPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        //- 1.630475

        if (TheMainPlayer.transform.position.x > TheLevel.GetLeftCameraBoundry().transform.position.x &&
            TheMainPlayer.transform.position.x < TheLevel.GetRightCameraBoundry().transform.position.x)
        {
            this.transform.position = new Vector3(TheMainPlayer.transform.position.x,
                this.transform.position.y, this.transform.position.z);
        }
        else
        {
            Debug.Log("Wont move camera");
        }
    }
}
