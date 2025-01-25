using UnityEngine;

public class collectibleSpawner : Spawner
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        timerValue -= Time.deltaTime * Gamemanager.Instance.boostMultiplierValue;
        if (timerValue <= 0)
        {
            timerValue = timer;
            int rand = Random.Range(0, 100);
            
            if (rand <= 50) {
                GameObject obstacle = Instantiate(Obstacles[1]);
                obstacle.transform.position = new Vector2(Random.Range(transform.position.x, transform.position.x + 4), transform.position.y);
            }
            else
            {
                GameObject obstacle = Instantiate(Obstacles[0]);
                obstacle.transform.position = new Vector2(Random.Range(transform.position.x, transform.position.x + 4), transform.position.y);
            }
        }
    }
}
