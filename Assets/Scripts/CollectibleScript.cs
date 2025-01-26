using UnityEngine;

public class CollectibleScript : FallingObject
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SoundEffectsPlayer.Instance.audioSource.PlayOneShot(SoundEffectsPlayer.Instance.sfxCheese);
            Gamemanager.Instance.IncreaseBoost();
            Destroy(gameObject);

        }
    }
}
