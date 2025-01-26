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
        if(lvl != 1 && lvl != 3)
        {
            return;
        }
        if (lvl == 1) {
            timerValue -= Time.deltaTime * Gamemanager.Instance.boostMultiplierValue;
        }
        else if(lvl == 3)
        {
            timerValue -= Time.deltaTime * Gamemanager.Instance.boostMultiplierValue;
        }
        
        if (timerValue <= 0)
        {
            if (lvl == 1)
            {
                timerValue = timer;
            }
            
            if(lvl == 3)
            {
                timerValue = timer + 1;
            }
            int rand = Random.Range(0, 2);
            if (lvl == 1)
            {
                GameObject obstacle = Instantiate(Obstacles[0]);
                spawn(rand, obstacle);
            }
            else
            {
                GameObject obstacle = Instantiate(Obstacles[1]);
                
            }
            
        }
    }

    private void spawn(int rand, GameObject obstacle)
    {
        if (rand == 0)
        {

            obstacle.transform.position = new Vector2(transform.position.x + 4, transform.position.y+10);
        }
        else
        {
            obstacle.GetComponent<CloudScript>().Setup(-1);
            obstacle.transform.position = new Vector2(transform.position.x, transform.position.y+10);
        }
    }
}
