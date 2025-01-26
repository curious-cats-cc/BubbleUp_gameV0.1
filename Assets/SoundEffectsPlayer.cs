using UnityEngine;

public class SoundEffectsPlayer : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip sfxBubble, sfxCheese, sfxPowerUp, sfxHit, sfxGameOver;

    public static SoundEffectsPlayer Instance { get; private set; }
    public void playSound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
