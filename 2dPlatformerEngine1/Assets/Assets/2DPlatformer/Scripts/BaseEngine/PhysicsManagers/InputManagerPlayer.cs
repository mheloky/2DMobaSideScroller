using Assets._2DPlatformer.Scripts.BaseEngine.GameStructure;
using Assets._2DPlatformer.Scripts.BaseEngine.PhysicsManagers;
using PhysicsObjects;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TCPIPGame.Messages;
using UnityEngine;

public class InputManagerPlayer : MonoBehaviour, AInputManager
{
    #region Properties
    public MainThreadSyncronizer TheMainThreadSyncronizer;
    public float NetworkHorizontalAxis
    {
        get;
        set;
    }
    public bool NetworkJump
    {
        get;
        set;
    }
    public APhysicsObject ThePhysicsObject
    {
        get;
        set;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        ThePhysicsObject = GetComponent<APhysicsObject>();
        GameRoomStatus.TheNetworkManager.OnSendUserInputResponseReceived += TheNetworkManager_OnSendUserInputResponseReceived;
    }

    // Update is called once per frame
    void Update()
    {
        var playerBody = GameRoomStatus.GetPhysicalPlayer(GameRoomStatus.ClientID);
        var horizontalAxis = GetHorizontalAxis();
        var jump = Input.GetButtonDown("Jump");

        var gameInputLocal = new GameInput() { ClientID = GameRoomStatus.ClientID, HorizontalAxis = horizontalAxis, Jump = jump }; //does not have position data since thats managed locally
        var networkUserInput = new NetworkUserInput(playerBody.transform.position.x, playerBody.transform.position.y, horizontalAxis, jump); //has position data which will be sent to network

        Update_FromUserInput(gameInputLocal);
        Update_SendUserInputToNetwork(networkUserInput);
        ThePhysicsObject.ExecuteJumpLogic(jump);
    }

    public void ExecuteInput(AGameInput gameInput)
    {
        TheMainThreadSyncronizer.Actions.Add(() =>
        {
            var playerBody = GameRoomStatus.GetPhysicalPlayer(gameInput.ClientID);

            var move = Vector2.zero;
            move.x = gameInput.HorizontalAxis ?? move.x;
            var positionX = gameInput.PositionX ?? playerBody.transform.position.x;
            var positionY = gameInput.PositionY ?? playerBody.transform.position.y;

            NetworkHorizontalAxis = move.x;
            NetworkJump = gameInput.Jump.Value;
            playerBody.transform.position = new Vector3(positionX, positionY);
        });
    }

    void Update_FromUserInput(AGameInput gameInput)
    {
        ExecuteInput(gameInput);
    }

    void Update_SendUserInputToNetwork(NetworkUserInput networkUserInput)
    {
        GameRoomStatus.TheNetworkManager.SendMessageToServer(new MessageSendUserInputRequest(networkUserInput));
    }

    private void TheNetworkManager_OnSendUserInputResponseReceived(object sender, MessageSendUserInputResponse e)
    {
        if (e.ClientID != GameRoomStatus.ClientID)
        {
            var gameInput = new GameInput() { ClientID = e.ClientID, HorizontalAxis = e.TheUserInput.HorizontalAxis, Jump = e.TheUserInput.Jump };
            ExecuteInput(gameInput);
        }
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
}
