using UnityEngine;

public class CloudSpawner : Spawner
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        int lvl = LevelManager.Instance.level;
        if(lvl != 1)
        {
            Destroy(gameObject);
        }
        timerValue -= Time.deltaTime * Gamemanager.Instance.boostMultiplierValue;
        if (timerValue <= 0)
        {
            timerValue = timer;
            int rand = Random.Range(0, 2);
            GameObject obstacle = Instantiate(Obstacles[0]);
            if (rand == 0)
            {
                
                obstacle.transform.position = new Vector2(transform.position.x + 4, transform.position.y);
            }
            else
            {
                obstacle.GetComponent<CloudScript>().Setup(-1);
                obstacle.transform.position = new Vector2(transform.position.x, transform.position.y);
            }
        }
    }
}
