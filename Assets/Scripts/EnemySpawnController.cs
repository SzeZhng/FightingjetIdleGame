using UnityEngine;

public class EnemySpawnController : MonoBehaviour {
    public EnemySpawnManager Manager;

    private void Awake() 
    {
        Manager = GetComponent<EnemySpawnManager>();
    }
}