﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TCPIPGame;
using TCPIPGame.Server.DomainObjects;
using Assets._2DPlatformer.Scripts.BaseEngine.GameStructure;
using TCPIPGame.Messages;

public class Player : PhysicsObject, APhysicalPlayer, AMovable
{

    #region Properties
    public float maxSpeed = 4;
    public float JumpSpeed = 7;

    public AudioSource TheFootstepsAudioSource;
    public AudioClip TheFootstepsAudioClip;
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
    public APlayer ThePlayer
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

    public void PlayFootStep()
    {
        TheFootstepsAudioSource.Play();
        AudioSource.PlayClipAtPoint(TheFootstepsAudioClip, new Vector3());
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
        if (this.NetworkJump && ThePhysicsObjectStatus.isGrounded)
        {
            Velocity.y = JumpSpeed;
        }
        else if (this.NetworkJump)
        {
            Velocity.y = Velocity.y > 0 ? Velocity.y * .5f : Velocity.y;
        }
    }

    void ExecuteFlipSpriteLogic()
    {
        Vector2 move = Vector2.zero;
        //move.x = Input.GetAxis("Horizontal");
        move.x = NetworkHorizontalAxis;
        //GameRoomStatus.TheNetworkManager.SendMessageToServer(new MessageSendUserInputRequest(new UserInput(Input.GetAxis("Horizontal"))));
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
        TheAnimator.SetFloat("velocityX", Mathf.Abs(Velocity.x) / maxSpeed);
        TheAnimator.SetBool("IsWalking", this.NetworkHorizontalAxis != 0f);
        TheAnimator.SetBool("IsBasicAttacking", Input.GetKey(KeyCode.X));
        TheAnimator.SetBool("IsBasicGuarding", Input.GetKey(KeyCode.Z));
        //TheAnimator.SetBool("IsWalking", Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.LeftArrow));
        //TheAnimator.SetBool("IsRunning", this.NetworkHorizontalAxis != 0f && Math.Abs(Velocity.x)>3);
    }
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public bool GetActive(bool active)
    {
        return gameObject.activeSelf;
    }

    private void TheNetworkManager_OnSendUserInputResponseReceived(object sender, MessageSendUserInputResponse e)
    {
        //GameRoomStatus.GetPhysicalPlayer(e.ClientID).NetworkHorizontalAxis = e.TheUserInput.HorizontalAxis;
    }
    #endregion
    // Update is called once per frame

}
