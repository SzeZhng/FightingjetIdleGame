using UnityEngine;
using UnityEngine.SceneManagement;

public class StageList : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StagePressed()
    {
        SceneManager.LoadScene("Stage0");
    }
}
