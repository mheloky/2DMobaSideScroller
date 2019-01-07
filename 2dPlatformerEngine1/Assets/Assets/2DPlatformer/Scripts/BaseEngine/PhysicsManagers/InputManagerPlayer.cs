using Assets._2DPlatformer.Scripts.BaseEngine.GameStructure;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TCPIPGame.Messages;
using UnityEngine;

public class InputManagerPlayer : MonoBehaviour
{
    public MainThreadSyncronizer TheMainThreadSyncronizer;

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

    public void ExecuteInput(int clientID, float horizontalAxis, bool jump, float positionX, float positionY)
    {
        TheMainThreadSyncronizer.Actions.Add(() =>
        {
            Vector2 move = Vector2.zero;
            move.x = horizontalAxis;

            var playerBody = GameRoomStatus.GetPhysicalPlayer(clientID);
            playerBody.NetworkHorizontalAxis = move.x;
            playerBody.NetworkJump = jump;
            playerBody.transform.position = new Vector3(positionX, positionY);
        });
    }

    // Update is called once per frame
    void Update()
    {
        var playerBody = GameRoomStatus.GetPhysicalPlayer(GameRoomStatus.ClientID);
        var horizontalAxis = GetHorizontalAxis();
        var jump = Input.GetButtonDown("Jump");
        ExecuteInput(GameRoomStatus.ClientID, horizontalAxis, jump);

        var userInput = new UserInput(playerBody.transform.position.x, playerBody.transform.position.y,horizontalAxis, jump);
       // var data = userInput.GetLowLevelData();
        //var z= new byte[] { 10, 12 };
        //GameRoomStatus.TheNetworkManager.SendLowLevelMessageToServer(data);
        GameRoomStatus.TheNetworkManager.SendMessageToServer(new MessageSendUserInputRequest(userInput));
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
            ExecuteInput(e.ClientID, e.TheUserInput.HorizontalAxis, e.TheUserInput.Jump,e.TheUserInput.PositionX,e.TheUserInput.PositionY);
        }
    }
}
