using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int[] altLevels;
    [SerializeField] int[] taltLevels;
    float timeElapsed = 0f;
    float duration = 2f;
    [SerializeField] Color[] colors;
    [SerializeField] Camera cam;
    public Material material;
    private int currentColorIndex = 0;
    private int targetColorIndex = 0;
    private float targetPoint;
    private float targetPoint1;
    private float targetPoint2;
    private float targetPoint3;
    private float targetPoint4;
    public float time;
    bool colorTransitioning = false;
    public float similarityThreshold = 0.15f;
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
        //print(level);
        float alt = Gamemanager.Instance.altitude;
        
        if (alt > altLevels[3])
        {
            level = 5;
            colorTransitioning = true;
            targetColorIndex = 4;
            targetPoint3 += Time.deltaTime / time * Gamemanager.Instance.boostMultiplierValue;
            cam.GetComponent<Camera>().backgroundColor = Color.Lerp(colors[3], colors[4], targetPoint3);
        }
        else if(alt > altLevels[2])
        {
            level = 4;
            colorTransitioning = true;
            targetColorIndex = 3;
            targetPoint2 += Time.deltaTime / time * Gamemanager.Instance.boostMultiplierValue;
            cam.GetComponent<Camera>().backgroundColor = Color.Lerp(colors[2], colors[3], targetPoint2);
        }
        else if (alt > altLevels[1])
        {
            level = 3;
            colorTransitioning = true;
            targetColorIndex = 2;
            targetPoint1 += Time.deltaTime / time * Gamemanager.Instance.boostMultiplierValue;
            cam.GetComponent<Camera>().backgroundColor = Color.Lerp(colors[1], colors[2], targetPoint1);
        }
        else if(alt > altLevels[0])
        {
            level = 2;
            
            colorTransitioning = true;
            targetColorIndex = 1;
            targetPoint += Time.deltaTime / time * Gamemanager.Instance.boostMultiplierValue;
            cam.GetComponent<Camera>().backgroundColor = Color.Lerp(colors[0], colors[1], targetPoint);

        }
        //Transition();
        //cam.GetComponent<Camera>().backgroundColor
    }

    
    
}
