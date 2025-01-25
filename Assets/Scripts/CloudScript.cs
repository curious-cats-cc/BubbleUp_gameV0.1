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
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        rb.linearVelocityX = -horizSpeed * Time.deltaTime;
    }
}
