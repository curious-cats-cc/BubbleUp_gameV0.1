using TMPro;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] float alt_per_sec;
    float timer = 1;
    float timerValue;

    [SerializeField] GameObject altitudeTextObj;
    // Update is called once per frame
    void Update()
    {
        timerValue += Time.deltaTime * 20;
        altitudeTextObj.GetComponent<TextMeshProUGUI>().text = "Altitude: " + timerValue.ToString("F0") + "m";
    }
}
