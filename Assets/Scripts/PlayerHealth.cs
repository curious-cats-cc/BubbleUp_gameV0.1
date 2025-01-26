using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance { get; private set; }

    [SerializeField] int maxHealth;
    public BubbleMouseScript BubbleMouseScript;
    [SerializeField] float immunTimer = 0.3f;
    float immunTimerValue = 0.1f;

    int health = 1;
    bool canTakeDamage = true;
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
        health = maxHealth;
    }
    private void Start()
    {
        
    }
    public int GetHealth()
    {
        return health;
    }
    // Update is called once per frame
    void Update()
    {
        if(immunTimerValue >= 0)
        {
            immunTimerValue -= Time.deltaTime;
            if(immunTimerValue < 0)
            {
                canTakeDamage = true;
            }
            
        }
        if (health <= 0)
        {
            print("U died lol");
            Gamemanager.Instance.SwitchScene(3);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && canTakeDamage) {
            canTakeDamage = false;
            immunTimerValue = immunTimer;
            health -= collision.GetComponent<ObstacleScript>().damage;
            HealthPanel.Instance.ChangeHealth();
            BubbleMouseScript.MakeBubbleBigger(health);
            GetComponent<CircleCollider2D>().radius = 0.5f + (health - 1) * 0.056f;
        }
    }
    public void increaseHealth(int value = 1)
    {
        if (health+value <= maxHealth && canTakeDamage) { 
            health += value;
            canTakeDamage = false;
            immunTimerValue = immunTimer;
            HealthPanel.Instance.ChangeHealth();
            BubbleMouseScript.MakeBubbleBigger(health);
            GetComponent<CircleCollider2D>().radius = 0.5f + (health - 1) * 0.056f;
        }
    }
    public void SetImmortal(bool value)
    {
        canTakeDamage = !value;
    }

}
