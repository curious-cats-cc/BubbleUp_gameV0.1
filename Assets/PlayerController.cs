using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputSystem_Actions inputSystem;
    float direction;
    Rigidbody2D rb;
    [SerializeField] float speed = 300;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        inputSystem = new InputSystem_Actions();
        inputSystem.Enable();




    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        direction = inputSystem.Player.Movement.ReadValue<float>();
        print(direction);
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction * Time.deltaTime * speed, 0);
    }
}
