using Assets._2DPlatformer.Scripts.BaseEngine.GameStructure;
using System.Collections;
using System.Collections.Generic;
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
        var horizontalAxis= Input.GetAxis("Horizontal");
        var jump = Input.GetButtonDown("Jump");
        ExecuteInput(GameRoomStatus.ClientID, horizontalAxis, jump);
        GameRoomStatus.TheNetworkManager.SendMessageToServer(new MessageSendUserInputRequest(new UserInput(horizontalAxis, jump)));
    }

    private void TheNetworkManager_OnSendUserInputResponseReceived(object sender, MessageSendUserInputResponse e)
    {
        if(e.ClientID!=GameRoomStatus.ClientID)
        {
            ExecuteInput(e.ClientID, e.TheUserInput.HorizontalAxis, e.TheUserInput.Jump);
        }
    }
}
