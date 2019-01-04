﻿using Assets._2DPlatformer.Scripts.BaseEngine.GameStructure;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TCPIPGame.Messages;
using UnityEngine;

public class InputManagerPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameRoomStatus.TheNetworkManager.OnSendUserInputResponseReceived += TheNetworkManager_OnSendUserInputResponseReceived;
    }

    public void ExecuteInput(int clientID, float horizontalAxis, bool jump)
    {
        Vector2 move = Vector2.zero;
        move.x = horizontalAxis;

        var playerBody = GameRoomStatus.GetPhysicalPlayer(clientID);
        playerBody.NetworkHorizontalAxis = move.x;
        playerBody.NetworkJump = jump;
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalAxis = GetHorizontalAxis();
        var jump = Input.GetButtonDown("Jump");
        ExecuteInput(GameRoomStatus.ClientID, horizontalAxis, jump);

        var userInput = new UserInput(horizontalAxis, jump);
        var data = userInput.GetLowLevelData();
        var z= new byte[] { 10, 12 };
        GameRoomStatus.TheNetworkManager.SendLowLevelMessageToServer(data);
    }

    float GetHorizontalAxis()
    {
        var HorizontalAxis = Input.GetAxis("Horizontal");
        var horizontalAxis = 0;

        if (HorizontalAxis < 0)
        {
            horizontalAxis = -1;
        }
        if (HorizontalAxis == 0)
        {
            horizontalAxis = 0;
        }
        if (HorizontalAxis > 0)
        {
            horizontalAxis = 1;
        }

        return horizontalAxis;
    }

    private void TheNetworkManager_OnSendUserInputResponseReceived(object sender, MessageSendUserInputResponse e)
    {
        if(e.ClientID!=GameRoomStatus.ClientID)
        {
            ExecuteInput(e.ClientID, e.TheUserInput.HorizontalAxis, e.TheUserInput.Jump);
        }
    }
}
