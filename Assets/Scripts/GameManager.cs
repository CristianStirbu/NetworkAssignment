using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class GameManager : NetworkBehaviour
{

    [SerializeField] private GameObject enemy;
    [SerializeField] private float miniumSpwanTime;
    [SerializeField] private float maxiumSpwanTime;
    [SerializeField] private float timeUnitlSpwan;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        SetTimeUntilSpawn();
    }

    void Update()
    {

        if (NetworkManager.Singleton.IsHost)
        {
            timeUnitlSpwan -= Time.deltaTime;
            if (timeUnitlSpwan <= 0)
            {
                Instantiate(enemy, transform.position, Quaternion.identity);
                SetTimeUntilSpawn();
            }
        }
        
    }

    private void SetTimeUntilSpawn()
    {
        timeUnitlSpwan = Random.Range(miniumSpwanTime, maxiumSpwanTime);
    }
}
