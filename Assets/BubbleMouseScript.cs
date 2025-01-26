using UnityEngine;

public class BubbleMouseScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float baseScale = 0.2f;
    private void Awake()
    {
        
    }
    void Start()
    {
        PlayerHealth.Instance.BubbleMouseScript = this;
        MakeBubbleBigger(4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeBubbleBigger(int health)
    {
        float newScale = baseScale + ((health-1) * 0.03f);
        if (health == 0)
        {
            newScale = 0;
        }
        transform.localScale = new Vector3(newScale, newScale, newScale);
    }
}
