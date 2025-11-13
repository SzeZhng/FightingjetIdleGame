using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    private GameObject EnemyType;
    public static string EnemyName;
    private float[] EnemyRoute;
    private int[] EnemyPattern;
    private void Awake()
    {
        return;
    }
    private void Update()
    {
        // Set EnemyType to selected EnemyName
        EnemyType = GameObject.Find(EnemyName);
    }
}
