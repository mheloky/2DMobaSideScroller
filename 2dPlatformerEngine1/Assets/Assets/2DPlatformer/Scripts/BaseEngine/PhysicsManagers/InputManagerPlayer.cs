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

    public void ExecuteInput(int clientID, float horizontalAxis, bool jump)
    {
        Vector2 move = Vector2.zero;
        move.x = horizontalAxis;

        var playerBody = GameRoomStatus.GetPhysicalPlayer(clientID);
        NetworkHorizontalAxis = move.x;
        NetworkJump = jump;
    }

    public void ExecuteInput(int clientID, float horizontalAxis, bool jump, float positionX, float positionY)
    {
        TheMainThreadSyncronizer.Actions.Add(() =>
        {
            Vector2 move = Vector2.zero;
            move.x = horizontalAxis;

            var playerBody = GameRoomStatus.GetPhysicalPlayer(clientID);
            NetworkHorizontalAxis = move.x;
            NetworkJump = jump;
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

        var userInput = new UserInput(playerBody.transform.position.x, playerBody.transform.position.y, horizontalAxis, jump);
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
        if (e.ClientID != GameRoomStatus.ClientID)
        {
            ExecuteInput(e.ClientID, e.TheUserInput.HorizontalAxis, e.TheUserInput.Jump, e.TheUserInput.PositionX, e.TheUserInput.PositionY);
        }
    }

    void ExecuteJumpLogic()
    {
        if (NetworkJump && ThePhysicsObject.ThePhysicsObjectStatus.isGrounded)
        {
            ThePhysicsObject.Velocity = new Vector2(ThePhysicsObject.Velocity.x, ThePhysicsObject.TheJumpSpeed);
        }
        else if (this.NetworkJump)
        {
            var y = ThePhysicsObject.Velocity.y > 0 ? ThePhysicsObject.Velocity.y * .5f : ThePhysicsObject.Velocity.y;
            ThePhysicsObject.Velocity = new Vector2(ThePhysicsObject.Velocity.x, y);
        }
    }

    void FixedUpdate()
    {
        ExecuteJumpLogic();
    }
}
