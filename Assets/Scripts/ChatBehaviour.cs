using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.Collections;
using Mirror;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking.PlayerConnection;

public class ChatBehaviour : NetworkBehaviour
{
    [SerializeField] private GameObject chatUI = null;
    [SerializeField] private TMP_Text chatText = null;
    [SerializeField] private TMP_InputField inputField = null;

    private static event Action<string> OnMessage;
    // Start is called before the first frame update

    public override void OnStartAuthority()
    {
       
        chatUI.SetActive(true);
        OnMessage += HandleNewMessage;
        base.OnStartAuthority();
    }

    [ClientCallback]
    private void OnDestroy()
    {
        if(!authority) {return;}
        OnMessage -= HandleNewMessage;
    }

    private void HandleNewMessage(string message)
    {
        chatText.text += message;
    }


    [Client]
    public void Send(string message)
    {
        if(Input.GetKeyDown(KeyCode.Return)) {return;}
        if(string.IsNullOrWhiteSpace(message)) {return;}

        cmdSendMessage(inputField.text);

        inputField.text = string.Empty;
    }

    [Command]
    private void cmdSendMessage(string message)
    {
        //validate the massage
        RpcHandleMessage($"[{connectionToClient.connectionId}]: {message}");
    }

    [ClientRpc]
    private void RpcHandleMessage(string message)
    {
        OnMessage?.Invoke($"\n{message}");
    }

    

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
