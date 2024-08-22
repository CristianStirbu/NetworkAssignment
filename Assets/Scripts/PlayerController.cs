using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour 
{
    [SerializeField] private float speed = 3f;
    private Camera mainCamera;
    private Vector3 mouseInput;
    
    private void Initialize()
    {
        mainCamera = Camera.main;
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        Initialize();
    }

    private void Update()
    {
        if (!Application.isFocused) return;

        mouseInput.x = Input.mousePosition.x;
        mouseInput.y = Input.mousePosition.y;
        mouseInput.z = mainCamera.nearClipPlane;
        Vector3 mouseWorldCoordinates = mainCamera.ScreenToWorldPoint(mouseInput);
        mouseWorldCoordinates.z = 0f;
        transform.position = Vector3.MoveTowards(transform.position, mouseWorldCoordinates, Time.deltaTime * speed);

        if (mouseWorldCoordinates != transform.position)
        {
            Vector3 targetDirection = mouseWorldCoordinates - transform.position;
            transform.up = targetDirection;
            //targetDirection.Z = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsHost) return;

        if (collision.gameObject.GetComponent<EnemyScrpit>())
        {
            Destroy(gameObject);
        }
    }

}