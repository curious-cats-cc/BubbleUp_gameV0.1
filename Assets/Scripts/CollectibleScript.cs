using UnityEngine;

public class CollectibleScript : FallingObject
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Gamemanager.Instance.IncreaseBoost();
            Destroy(gameObject);

        }
    }
}
