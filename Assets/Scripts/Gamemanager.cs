using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{

    public static Gamemanager Instance { get; private set; }

    public int boostValue;
    [SerializeField] int maxBoostValue = 4;
    bool canBoost = false;

    [SerializeField] float punishmentTimer = 4;
    float punishmentTimerValue = 5;

    [SerializeField] GameObject Player;
    [SerializeField] GameObject Meteor;
    Vector2 PlayerPos;
    public float boostMultiplierValue { get; private set; } = 1;
    [SerializeField] float boosMultiplier = 20f;
    [SerializeField] float boostDuration = 10;
    float boostDurationValue;
    public bool PlayerMoved;
    bool PlayerLastMoved = false;

    [SerializeField] GameObject boostCommand;
    float elapsedTime;
    bool isBoosting;
    bool isunBoosting;

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

    [SerializeField] float alt_per_sec;
    float timer = 1;
    public float altitude { get; private set; }

    float altitudepersec = 600;

    [SerializeField] GameObject altitudeTextObj;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        altitude += Time.deltaTime * altitudepersec * boostMultiplierValue;
        punishmentTimerValue -= Time.deltaTime;
        if (PlayerMoved)
        {
            punishmentTimerValue = punishmentTimer;
        }

        if (altitude < 1000)
        {
            altitudeTextObj.GetComponent<TextMeshProUGUI>().text = altitude.ToString("F0") + "m";
        }
        else {
            altitudeTextObj.GetComponent<TextMeshProUGUI>().text = (altitude / 1000).ToString("F1") + "km";
        }

        if (Player == null) { return; }

        if (punishmentTimerValue < 0 && !isBoosting && !isunBoosting && PlayerMoved == false && PlayerLastMoved == false)
        {
            punishmentTimerValue = punishmentTimer;
            
            
            Instantiate(Meteor, new Vector2(Player.transform.position.x, Player.transform.position.y + 9.5f), Quaternion.identity);
                

            
        }

        if (isBoosting) {
            boostDurationValue -= Time.deltaTime;
            elapsedTime += Time.deltaTime;

    
            float t = Mathf.Clamp01(elapsedTime / 2);

            
            float newX = Mathf.Lerp(1, boosMultiplier, t);

            
            boostMultiplierValue = newX;
            if(boostDurationValue <= 0)
            {
                isBoosting = false;
                isunBoosting = true;
                elapsedTime = 0;
            }
        }
        else if (isunBoosting)
        {
            elapsedTime += Time.deltaTime;

         
            float t = Mathf.Clamp01(elapsedTime / 3);

          
            float newBoost = Mathf.Lerp(boosMultiplier, 1, t);

           
            boostMultiplierValue = newBoost;
            if(boostMultiplierValue == 1)
            {
                
                isunBoosting = false;
                PlayerHealth.Instance.SetImmortal(false);
                boostMultiplierValue = 1;
                elapsedTime = 0;
            }
        }
        
    }

    public void IncreaseBoost(int amount = 1)
    {
        if (!canBoost && !isunBoosting && !isBoosting)
        {
            boostValue += amount;
            
            boostCommand.GetComponent<Image>().fillAmount = (float)boostValue / (float)maxBoostValue;
            
            if (boostValue == maxBoostValue)
            {
                canBoost = true;
            }
        }
    }
    public void Boost()
    {
        if (canBoost)
        {
            SoundEffectsPlayer.Instance.audioSource.PlayOneShot(SoundEffectsPlayer.Instance.sfxPowerUp);
            canBoost = false;
            boostValue = 0;
            boostCommand.GetComponent<Image>().fillAmount = (float)boostValue / (float)maxBoostValue;
            isBoosting = true;
            PlayerHealth.Instance.SetImmortal(true);
            boostDurationValue = boostDuration;
        }

    }
    public void SwitchScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
