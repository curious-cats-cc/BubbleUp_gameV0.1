using UnityEngine;

public class CloudScript : FallingObject
{
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] sprites;
    [SerializeField] float horizSpeed = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        speed = Random.Range(speed - 50, speed + 40);
    }
    public void Setup(int dir)
    {
        if (dir == -1) {
            horizSpeed = -horizSpeed;
        }
    }
    // Update is called once per frame
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        rb.linearVelocityX = -horizSpeed * Time.deltaTime;
    }
}
