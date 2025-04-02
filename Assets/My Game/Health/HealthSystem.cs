using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public float currentHealth;
    [SerializeField]
    private float maxHealth;

    public Slider healthbar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;    
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            PlayDeath();
        }

        healthbar.value = (currentHealth / maxHealth);
    }

    public void TakeDamage(float damage)
    {
        float remainingHealth = currentHealth - damage;
        remainingHealth = remainingHealth > 0 ? remainingHealth : 0;
        currentHealth = remainingHealth;        
    }

    public void HealDamage(float healAmount)
    {
        float remainingHealth = currentHealth + healAmount;
        remainingHealth = remainingHealth > maxHealth ? maxHealth: remainingHealth;
        currentHealth = remainingHealth;
    }

    void PlayDeath()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
