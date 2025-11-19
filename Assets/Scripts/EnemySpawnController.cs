using UnityEngine;

public class EnemySpawnController : MonoBehaviour {
    private GameObject EnemyType;
    public EnemySpawnManager Manager;
    public EnemyData Data; 

    private void Awake() 
    {
        Manager = GetComponent<EnemySpawnManager>();
    }
    private void Update()
    {
        // Set EnemyType to selected EnemyName
        EnemyType = GameObject.Find(Data.EnemyName);
    }
    public void PathFind(str type, float[] startpoint, float[] endpoint, float[] midpoint)
    {

    }
}