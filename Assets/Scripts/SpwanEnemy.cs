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
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeUnitlSpwan -= Time.deltaTime;
        if(timeUnitlSpwan <=0)
        {
            Instantiate(enemy,transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

     private void SetTimeUntilSpawn()
     {
        timeUnitlSpwan = Random.Range(miniumSpwanTime,maxiumSpwanTime);
     }
}
