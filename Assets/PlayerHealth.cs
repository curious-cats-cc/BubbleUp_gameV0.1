using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance { get; private set; }

    [SerializeField] int maxHealth;
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

    // Update is called once per frame
    void Update()
    {
        print(health);
        if (health <= 0)
        {
            print("U died lol");
            Gamemanager.Instance.SwitchScene(1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && canTakeDamage) { 
            health -= collision.GetComponent<ObstacleScript>().damage;
            print("DSA ");
        }
    }

    public void SetImmortal(bool value)
    {
        canTakeDamage = !value;
    }

}
