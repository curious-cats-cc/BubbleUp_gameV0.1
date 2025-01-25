using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SOLevel", order = 1)]
public class SOLevelData : ScriptableObject
{
    public int level;

    public GameObject[] Collectibles;
    public GameObject[] Obstacles;

    public int chanceCol1;
    public int chanceCol2;
}