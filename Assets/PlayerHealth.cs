using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int health = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        print(health);
        if (health <= 0)
        {
            print("U died lol");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") { 
            health -= collision.GetComponent<ObstacleScript>().damage;
            print("DSA ");
        }
    }

}
