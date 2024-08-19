using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class SpwanEnemy : NetworkBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject enemy;
    [SerializeField] private float miniumSpwanTime;
    [SerializeField] private float maxiumSpwanTime;
    [SerializeField] private float timeUnitlSpwan;



    void Start()
    {
       
    }
   

    // Update is called once per frame
    void Update()
    {
        if (NetworkManager.Singleton.IsHost && NetworkManager.Singleton.IsClient)
        {
            timeUnitlSpwan -= Time.deltaTime;
            if (timeUnitlSpwan <= 0)
            {
                GameObject spawnedEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
                spawnedEnemy.GetComponent<NetworkObject>().Spawn();
                SetTimeUntilSpawn();
            }
        }
    }

     private void SetTimeUntilSpawn()
     {
        timeUnitlSpwan = Random.Range(miniumSpwanTime,maxiumSpwanTime);
     }
}
