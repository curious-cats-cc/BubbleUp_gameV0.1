using UnityEngine;

public class BubbleScript : FallingObject
{
    // SoundEffectsPlayer sfxScript;
    // [SerializeField] AudioClip bubble; 

    [SerializeField] Sprite[] sprites;
    SpriteRenderer spriteRenderer;
    void Awake()
    {
        // sfxScript = GameObject.FindGameObjectWithTag("audioManager").GetComponent<SoundEffectsPlayer>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        speed = Random.Range(speed - 50, speed + 40);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // sfxScript.playSound(bubble);

            PlayerHealth.Instance.increaseHealth();
            Destroy(gameObject);

        }
    }
}
