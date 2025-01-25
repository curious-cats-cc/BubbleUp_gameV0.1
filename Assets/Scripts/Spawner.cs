using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected SOLevelData[] solLvls;
    [SerializeField] protected GameObject[] Obstacles;
    [SerializeField] protected float timer = 3;
    protected float timerValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        int lvl = LevelManager.Instance.level-1;
        timerValue -= Time.deltaTime * Gamemanager.Instance.boostMultiplierValue;
        if(timerValue <= 0)
        {
            timerValue = timer;

            GameObject obstacle = Instantiate(solLvls[lvl].Obstacles[Random.Range(0, solLvls[lvl].Obstacles.Length)]);
            obstacle.transform.position = new Vector2(Random.Range(transform.position.x, transform.position.x + 4), transform.position.y);

        }

    }
}
