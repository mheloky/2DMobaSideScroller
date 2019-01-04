using Assets._2DPlatformer.Scripts.BaseEngine.GameStructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");
        var jump = Input.GetButtonDown("Jump");
        var playerBody = GameRoomStatus.GetPhysicalPlayer(GameRoomStatus.ClientID);
        playerBody.NetworkHorizontalAxis= move.x;
        playerBody.NetworkJump = jump;
    }
}
