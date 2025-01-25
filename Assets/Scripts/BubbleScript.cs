using UnityEngine;

public class BubbleScript : FallingObject
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerHealth.Instance.increaseHealth();
            Destroy(gameObject);

        }
    }
}
