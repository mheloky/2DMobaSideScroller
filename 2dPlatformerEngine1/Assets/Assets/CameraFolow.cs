using Assets._2DPlatformer.Scripts.BaseEngine.GameStructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    Player TheMainPlayer;

    // Start is called before the first frame update
    void Start()
    {
       this.GetComponent<Camera>().orthographicSize = 15;
       TheMainPlayer = GameRoomStatus.GetThisMainPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(TheMainPlayer.transform.position.x,this.transform.position.y, this.transform.position.z);
    }
}
