using System;
using System.Collections;
using System.Collections.Generic;
using TCPIPGame.Client;
using TCPIPGame.Messages;
using TCPIPGame.Server.DomainObjects;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public GameClient _gameClient;
    public event EventHandler<MessagePreConnectToServerResponse> OnPreConnectedToServerResponseReceived;
    public event EventHandler<MessageConnectToServerResponse> OnConnectedToServerResponseReceived;
    public event EventHandler<MessageCreateRoomResponse> OnCreateRoomResponseReceived;
    public event EventHandler<MessageGetGameRoomsResponse> OnGetGameRoomsResponseReceived;
    public event EventHandler<MessageGetGameRoomPlayersResponse> OnGetGameRoomPlayersResponseReceived;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Connect()
    {
        _gameClient = new GameClient();
        _gameClient.OnPreConnectedToServerResponseReceived += _gameClient_OnPreConnectedToServerResponseReceived;
        _gameClient.OnConnectedToServerResponseReceived += _gameClient_OnConnectedToServerResponseReceived;
        _gameClient.OnCreateGameRoomSuccessful += _gameClient_OnCreateGameRoomSuccessful;
        _gameClient.OnGetGameRoomsRequestSuccessful += _gameClient_OnGetGameRoomsRequestSuccessful;
        _gameClient.OnGetGameRoomPlayersRequestSuccessful += _gameClient_OnGetGameRoomPlayersRequestSuccessful;
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

    private void _gameClient_OnCreateGameRoomSuccessful(object sender, MessageCreateRoomResponse e)
    {
        if (OnCreateRoomResponseReceived != null)
        {
            OnCreateRoomResponseReceived(sender, e);
        }
    }

    private void _gameClient_OnGetGameRoomsRequestSuccessful(object sender, MessageGetGameRoomsResponse e)
    {
        if (OnGetGameRoomsResponseReceived != null)
        {
            OnGetGameRoomsResponseReceived(sender, e);
        }
    }

    private void _gameClient_OnGetGameRoomPlayersRequestSuccessful(object sender, MessageGetGameRoomPlayersResponse e)
    {
        if (OnGetGameRoomPlayersResponseReceived != null)
        {
            OnGetGameRoomPlayersResponseReceived(sender, e);
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
