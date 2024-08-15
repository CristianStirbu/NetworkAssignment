using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] private float speed = 3f;
    private Camera mainCamera;
    private Vector3 mouseInput;

    private void Initialized()
    {
        mainCamera = Camera.main;
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        Initialized();
    }
    private void Update()
    {
        if (!Application.isFocused) return;

        mouseInput.x = Input.mousePosition.x;
        mouseInput.y = Input.mousePosition.y;
        mouseInput.z = mainCamera.nearClipPlane;
        Vector3 mouseWorldCoordiantes = mainCamera.ScreenToWorldPoint(mouseInput);
        mouseWorldCoordiantes.z = 0;
        transform.position = Vector3.MoveTowards(current: transform.position, target: mouseWorldCoordiantes, Time.deltaTime * speed);
      
        if(mouseWorldCoordiantes != transform.position)
        {
            Vector3 targetDirection = mouseWorldCoordiantes - transform.position;
            targetDirection.z = 0f;
            transform.up = targetDirection;
        }

    }
}
