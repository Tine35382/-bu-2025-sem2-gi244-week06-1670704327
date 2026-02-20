using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExam02 : MonoBehaviour
{
    public float speed;
    public float zRange = 10f;
    public GameObject projectilePrefab;

    private float verticalInput;
    private InputAction moveAction;
    private InputAction shootAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    void Update()
    {
    
        verticalInput = moveAction.ReadValue<Vector2>().y;

        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime, Space.World);

      
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        else if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

       
        if (shootAction.triggered)
        {

            Instantiate(
                projectilePrefab,
                transform.position,
                Quaternion.Euler(0, 90, 0)
            );
        }
    }
}