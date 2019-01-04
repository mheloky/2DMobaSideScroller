using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TCPIPGame;
using TCPIPGame.Server.DomainObjects;
using Assets._2DPlatformer.Scripts.BaseEngine.GameStructure;
using TCPIPGame.Messages;

public class Player : PhysicsObject {

    #region Properties
    public float maxSpeed = 7;
    public float JumpSpeed = 7;
    public float NetworkHorizontalAxis
    {
        get;
        set;
    }
    SpriteRenderer TheSpriteRenderer
    {
        get;
        set;
    }
    Animator TheAnimator
    {
        get;
        set;
    }
    APlayer ThePlayer
    {
        get;
        set;
    }
    #endregion

    private void Awake()
    { 
        //All Looks Good
        TheSpriteRenderer = GetComponent<SpriteRenderer>();
        TheAnimator = GetComponent<Animator>();
        GameRoomStatus.TheNetworkManager.OnSendUserInputResponseReceived += TheNetworkManager_OnSendUserInputResponseReceived;
    }

    protected override void ExecutePerFrame()
    {
        ExecuteJumpLogic();
        ExecuteFlipSpriteLogic();
        ExecueChangeAnimationLogic();
    }

    #region Helper Methods
    void ExecuteJumpLogic()
    {
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && ThePhysicsObjectStatus.isGrounded)
        {
            Velocity.y = JumpSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            Velocity.y = Velocity.y > 0 ? Velocity.y * .5f : Velocity.y;
        }
    }

    void ExecuteFlipSpriteLogic()
    {
        Vector2 move = Vector2.zero;
        //move.x = Input.GetAxis("Horizontal");
        move.x = GetHorizontalAxis();
        GameRoomStatus.TheNetworkManager.SendMessageToServer(new MessageSendUserInputRequest(new UserInput(Input.GetAxis("Horizontal"))));
        if (move.x < 0f)
        {

            TheSpriteRenderer.flipX = true;
        }
        if (move.x > .0f)
        {

            TheSpriteRenderer.flipX = false;
        }

        targetVelocity = move * maxSpeed;
        //Debug.Log(move);
        //Debug.Log(maxSpeed+":"+targetVelocity);
    }

    void ExecueChangeAnimationLogic()
    {
        //TheAnimator.SetBool("grounded", ThePhysicsObjectStatus.isGrounded);
        TheAnimator.SetFloat("velocityX", Mathf.Abs(Velocity.x)/ maxSpeed);
        TheAnimator.SetBool("IsWalking", Input.GetAxis("Horizontal")!=0f);
        TheAnimator.SetBool("IsRunning", Input.GetAxis("Horizontal") != 0f && Math.Abs(Velocity.x)>3);
    }

    public float GetHorizontalAxis()
    {
        return NetworkHorizontalAxis;
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public bool GetActive(bool active)
    {
        return gameObject.activeSelf;
    }

    public void SetPlayer(APlayer player)
    {
        ThePlayer = player;
    }

    public APlayer GetPlayer()
    {
        return ThePlayer;
    }

    private void TheNetworkManager_OnSendUserInputResponseReceived(object sender, MessageSendUserInputResponse e)
    {
        //GameRoomStatus.GetPhysicalPlayer(e.ClientID).NetworkHorizontalAxis = e.TheUserInput.HorizontalAxis;
    }
    #endregion
    // Update is called once per frame

}
