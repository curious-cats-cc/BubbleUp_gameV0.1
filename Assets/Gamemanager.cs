using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{

    public static Gamemanager Instance { get; private set; }

    public int boostValue;
    [SerializeField] int maxBoostValue = 4;
    bool canBoost = false;
    public float boostMultiplierValue { get; private set; } = 1;
    [SerializeField] float boosMultiplier = 20f;
    [SerializeField] float boostDuration = 10;
    float boostDurationValue;

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
    float timerValue;

    float altitudepersec = 600;

    [SerializeField] GameObject altitudeTextObj;
    // Update is called once per frame
    void Update()
    {
        timerValue += Time.deltaTime * altitudepersec * boostMultiplierValue;
        if (timerValue < 1000)
        {
            altitudeTextObj.GetComponent<TextMeshProUGUI>().text = "Altitude: " + timerValue.ToString("F0") + "m";
        }
        else {
            altitudeTextObj.GetComponent<TextMeshProUGUI>().text = "Altitude: " + (timerValue/1000).ToString("F1") + "km";
        }

        print(boostMultiplierValue);

        if (isBoosting) {
            boostDurationValue -= Time.deltaTime;
            elapsedTime += Time.deltaTime;

            // Calculate the interpolation factor
            float t = Mathf.Clamp01(elapsedTime / 2);

            // Interpolate the position along the X-axis
            float newX = Mathf.Lerp(1, boosMultiplier, t);

            // Update the object's position
            boostMultiplierValue = newX;
            if(boostDurationValue <= 0)
            {
                isBoosting = false;
                isunBoosting = true;
            }
        }
        else if (isunBoosting)
        {
            elapsedTime += Time.deltaTime;

            // Calculate the interpolation factor
            float t = Mathf.Clamp01(elapsedTime / 3);

            // Interpolate the position along the X-axis
            float newX = Mathf.Lerp(boosMultiplier, 1, t);

            // Update the object's position
            boostMultiplierValue = newX;
            if(boostMultiplierValue == 1)
            {
                
                isunBoosting = false;
                PlayerHealth.Instance.SetImmortal(false);
                boostMultiplierValue = 1;
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
