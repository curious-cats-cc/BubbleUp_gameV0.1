using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] Obstacles;
    [SerializeField] float timer = 3;
    float timerValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerValue -= Time.deltaTime * Gamemanager.Instance.boostMultiplierValue;
        if(timerValue <= 0)
        {
            timerValue = timer;
            GameObject obstacle = Instantiate(Obstacles[Random.Range(0, Obstacles.Length)]);
            obstacle.transform.position = new Vector2(Random.Range(transform.position.x, transform.position.x + 4), transform.position.y);

        }

    }
}
