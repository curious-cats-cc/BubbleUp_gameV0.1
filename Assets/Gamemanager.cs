using TMPro;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] float alt_per_sec;
    float timer = 1;
    float timerValue;

    float altitudepersec = 600;

    [SerializeField] GameObject altitudeTextObj;
    // Update is called once per frame
    void Update()
    {
        timerValue += Time.deltaTime * altitudepersec;
        if (timerValue < 1000)
        {
            altitudeTextObj.GetComponent<TextMeshProUGUI>().text = "Altitude: " + timerValue.ToString("F0") + "m";
        }
        else {
            altitudeTextObj.GetComponent<TextMeshProUGUI>().text = "Altitude: " + (timerValue/1000).ToString("F1") + "km";
        }

        
    }
}
