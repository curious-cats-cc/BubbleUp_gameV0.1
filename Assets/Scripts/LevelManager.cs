using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int[] altLevels;
    [SerializeField] int[] taltLevels;
    public static LevelManager Instance { get; private set; }
    public int level { get; private set; } = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
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

    // Update is called once per frame
    void Update()
    {
        print(level);
        float alt = Gamemanager.Instance.altitude;
        if(alt > taltLevels[4])
        {
            level = 5;
        }
        else if(alt > taltLevels[3])
        {
            level = 4;
        }
        else if (alt > taltLevels[2])
        {
            level = 3;
        }
        else if(alt > taltLevels[1])
        {
            level = 2;
        }

    }
}
