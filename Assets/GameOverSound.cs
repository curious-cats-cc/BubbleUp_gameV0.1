using UnityEngine;
using UnityEngine.Audio;

public class GameOverSound : MonoBehaviour
{
    [SerializeField] AudioSource AudioSource;
    [SerializeField] AudioClip audioClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        AudioSource.PlayOneShot(audioClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
