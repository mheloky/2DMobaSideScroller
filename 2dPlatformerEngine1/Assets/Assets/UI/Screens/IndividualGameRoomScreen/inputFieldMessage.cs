﻿using Assets.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TCPIPGame.Messages;
using UnityEngine.UI;

public class inputFieldMessage : MonoBehaviour
{
    public UIPresenter theUIPresenter = new UIPresenter();
    public NetworkManager TheNetworkManager;
    public MainThreadSyncronizer TheMainThreadSyncronizer;
    public Text txtMessages;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Setup()
    {
        TheNetworkManager.OnSendGameRoomTextMessageResponseReceived += TheNetworkManager_OnSendGameRoomTextMessageResponseReceived;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            print("space key was pressed");
            var inputField1 = GetComponent<InputField>();
            var inputField2 = GetComponentInChildren<InputField>();
            TheNetworkManager.SendMessageToServer(new MessageSendGameRoomTextMessageRequest(inputField1.text));
        }
    }

    private void TheNetworkManager_OnSendGameRoomTextMessageResponseReceived(object sender, MessageSendGameRoomTextMessageResponse e)
    {
        TheMainThreadSyncronizer.Actions.Add(() =>
        {
            txtMessages.text += e.TheMessage + "\r\n";
        });
    }
}