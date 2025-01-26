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
        int lvl = LevelManager.Instance.level - 1;
        timerValue -= Time.deltaTime * Gamemanager.Instance.boostMultiplierValue;
        if (timerValue <= 0)
        {
            timerValue = Random.Range(timer * 10 - 5, timer * 10 + 5) / 10.0f;
            int rand = Random.Range(0, 100);
            if (rand <= solLvls[lvl].chanceCol1)
            {
                print("DSAS D");
                GameObject obstacle = Instantiate(solLvls[lvl].Collectibles[0]);
                obstacle.transform.position = new Vector2(Random.Range(transform.position.x, transform.position.x + 4), transform.position.y);
            }
            else if (rand <= solLvls[lvl].chanceCol2) {
                GameObject obstacle = Instantiate(solLvls[lvl].Collectibles[1]);
                obstacle.transform.position = new Vector2(Random.Range(transform.position.x, transform.position.x + 4), transform.position.y);
            }
            
        }
    }
}
