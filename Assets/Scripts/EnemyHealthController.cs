using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public Slider healthSlider;
    public float maxDisplayHealth = 100f;
    private float currentDisplayHealth;
    public EnemyData Data;
    private float currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthSlider.maxValue = maxDisplayHealth;
        currentHealth = Data.maxHealth;
        currentDisplayHealth = currentHealth * maxDisplayHealth / Data.maxHealth;
        healthSlider.value = currentDisplayHealth;
    }

    public void HealthBarChange() {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
