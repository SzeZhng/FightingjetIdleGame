using UnityEngine;
using UnityEngine.SceneManagement;
public class OnStage : MonoBehaviour
{
    public EnemyData Data; 

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        // Subscribe to the event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    // Unsubscribe when the script is destroyed to prevent memory leaks
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Stage0")
        {
            Debug.Log("yes");
            Data.EnemyName = "a";
            Data.MovementType = "Line";
            Data.StartPoint = new Vector2(-300, -300); 
            Data.MidPoint = new Vector2(0, 0);
            Data.EndPoint = new Vector2(300, 300);
            Data.Speed = 10f;
            EnemySpawnController.Instance.SpawnEnemy(10, 3f);
        }
    }
}
