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
        
    }

    // Update is called once per frame
    void Update()
    {
       

       transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        
        if(player.transform.position != transform.position)
        {
            distance = Vector3.Distance(transform.position, player.transform.position);
            Vector3 direction = player.transform.position - transform.position;
            transform.up = direction;
        }
    
    }
}
