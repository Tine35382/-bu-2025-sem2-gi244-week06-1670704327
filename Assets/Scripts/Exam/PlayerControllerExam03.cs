using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExam03 : MonoBehaviour
{
    public float speed;
    public float xRange = 10;
    public GameObject projectilePrefab;

    [Header("Auto Fire Settings")]
    public bool enableAutoFireMode;
    public float autoFireInterval = 0.1f;

    private float horizontalInput;
    private InputAction moveAction;
    private InputAction shootAction;

    
    private float nextFireTime = 0f;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    void Update()
    {
        
        horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

        
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        
        if (enableAutoFireMode)
        {
            
            if (Time.time >= nextFireTime)
            {
                Fire(); 
                nextFireTime = Time.time + autoFireInterval;
            }
        }
        else
        {
           
            if (shootAction.triggered)
            {
                Fire();
            }
        }
    }

    
    private void Fire()
    {
        Instantiate(projectilePrefab, transform.position, transform.rotation);
    }
}