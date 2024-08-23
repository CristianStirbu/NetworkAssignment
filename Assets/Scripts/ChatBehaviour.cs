using System;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class ChatBehaviour : NetworkBehaviour
{
    [SerializeField] private GameObject chatUI;
    [SerializeField] private TMP_Text chatText ;
    [SerializeField] private TMP_InputField inputField;

    
    void Start()
    {
        chatText.SetText("");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SendMessage()
    { 
         AddTextServerRPC(inputField.text);
    }

   [ServerRpc(RequireOwnership = false)]
    void AddTextServerRPC(string text)
    {
        AddTextClientRPC(text);
    }

    [ClientRpc]
    void AddTextClientRPC(string text)
    {
        AddText(text);
    }

    void AddText(string chat)
    {
        string lastText = chatText.text;
        chatText.SetText(lastText + "\n" + chat);
    }

    public override void OnNetworkDespawn()
    {
        chatText.SetText("");
        base.OnNetworkDespawn();
    }
}
