using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] protected float speed;
    protected Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        rb.linearVelocityY = -speed * Time.deltaTime * Gamemanager.Instance.boostMultiplierValue;
    }
    protected virtual void Update()
    {
        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }
}