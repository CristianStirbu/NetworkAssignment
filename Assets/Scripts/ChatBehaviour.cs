using System;
using TMPro;
using Mirror;
using UnityEngine;

public class ChatBehaviour : NetworkBehaviour
{
    [SerializeField] private GameObject chatUI = null;
    [SerializeField] private TMP_Text chatText = null;
    [SerializeField] private TMP_InputField inputField = null;

    private static event Action<string> OnMessage;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnStartAuthority()
    {
        base.OnStartAuthority();
        OnMessage += HandleNewMessage;
        chatUI.SetActive(true);
        Debug.Log("loof");

    }

    [ClientCallback]
    private void OnDestroy()
    {
        OnMessage -= HandleNewMessage;
    }

    private void HandleNewMessage(string message)
    {

        chatText.text += message;
    }


    [Client]
    public void Send(string message)
    {
        Debug.Log("Send");
        if (!Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("im preesing");
            return;
        }

        if (string.IsNullOrWhiteSpace(message)) Debug.Log("There is no message");

        if (string.IsNullOrWhiteSpace(message)) { return; }

        cmdSendMessage(message);
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
        Debug.Log("written");
    }


}
