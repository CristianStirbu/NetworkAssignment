using Unity.Netcode;
using UnityEngine;

public class StartNetwork : NetworkBehaviour
{
    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();
    }

    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();

    }
}
