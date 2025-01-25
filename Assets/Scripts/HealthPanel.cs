using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class HealthPanel : MonoBehaviour
{
    public static HealthPanel Instance { get; private set; }
    [SerializeField] GameObject[] children;
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

    public void ChangeHealth()
    {
        for (int i = 0; i < 4; i++)
        {
            
            if (i < PlayerHealth.Instance.GetHealth()) {
                children[i].SetActive(true);
            }
            else
            {
                children[i].SetActive(false);
            }
        }
    }
}
