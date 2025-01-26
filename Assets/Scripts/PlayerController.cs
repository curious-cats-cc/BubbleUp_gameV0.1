using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    InputSystem_Actions inputSystem;
    float direction;
    Rigidbody2D rb;
    [SerializeField] float speed = 300;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        inputSystem = new InputSystem_Actions();
        inputSystem.Enable();


        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -2.6)
        {
            transform.position = new Vector2(-2.6f, transform.position.y);
        }
        else if (transform.position.x > 2.6)
        {
            transform.position = new Vector2(2.6f, transform.position.y);
        }
        direction = inputSystem.Player.Movement.ReadValue<float>();
        if(direction == -1)
        {
            spriteRenderer.flipX = true;
            Gamemanager.Instance.PlayerMoved = true;
        }
        else if(direction == 1)
        {
            spriteRenderer.flipX = false;
            Gamemanager.Instance.PlayerMoved = true;
        }
        else
        {
            Gamemanager.Instance.PlayerMoved = false;
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction * Time.deltaTime * speed, 0);
    }
}
