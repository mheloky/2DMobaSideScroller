using System;
using System.Collections;
using System.Collections.Generic;
using TCPIPGame.Client;
using TCPIPGame.Messages;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public GameClient _gameClient;
    public event EventHandler<MessagePreConnectToServerResponse> OnPreConnectedToServerResponseReceived;
    public event EventHandler<MessageConnectToServerResponse> OnConnectedToServerResponseReceived;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Connect()
    {
        _gameClient = new GameClient();
        _gameClient.OnPreConnectedToServerResponseReceived += _gameClient_OnPreConnectedToServerResponseReceived;
        _gameClient.OnConnectedToServerResponseReceived += _gameClient_OnConnectedToServerResponseReceived;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void _gameClient_OnPreConnectedToServerResponseReceived(object sender, MessagePreConnectToServerResponse e)
    {
        if (OnPreConnectedToServerResponseReceived != null)
        {
            OnPreConnectedToServerResponseReceived(sender, e);
        }
    }

    private void _gameClient_OnConnectedToServerResponseReceived(object sender, MessageConnectToServerResponse e)
    {
        if (OnConnectedToServerResponseReceived != null)
        {
            OnConnectedToServerResponseReceived(sender, e);
        }
    }

    public void SendMessageToServer(AClientMessage message)
    {
        _gameClient.SendMessageToServer(message);
    }

    public AGameClientStatus GetGameClientStatus()
    {
        return _gameClient.TheGameClientStatus;
    }
}
