using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class BulletSpawner : NetworkBehaviour
{

    [SerializeField] private GameObject bulled;
    [SerializeField] private Transform InistialTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SpawnBulletServerRPC(InistialTransform.position, InistialTransform.rotation);
        }
    }

    [ServerRpc(RequireOwnership = false)] private void SpawnBulletServerRPC(Vector3 position,Quaternion rotation)
    {
        GameObject InstansiateBullet = Instantiate(bulled, position, rotation);
        InstansiateBullet.GetComponent<NetworkObject>().Spawn();
    }
}

