using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class EnemyScrpit : NetworkBehaviour
{
    [SerializeField] private float speed = 5f;
    public GameObject player;
    private float distance;


    // Start is called before the first frame update
    void Start()
    {
        GameObject[] playerArray;
        playerArray = GameObject.FindGameObjectsWithTag("Player");
        player = playerArray[Random.Range(0, playerArray.Length)];
    }



    // Update is called once per frame
    void Update()
    {

        if (player != null)
        {
            if (player.transform.position != transform.position)
            {
                distance = Vector3.Distance(transform.position, player.transform.position);
                Vector3 direction = player.transform.position - transform.position;
                direction.z = 0;
                transform.up = direction;
            }
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

       
    }
}
