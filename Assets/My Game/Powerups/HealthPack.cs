using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public float healAmount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            HealthSystem playerHealth = collision.GetComponent<HealthSystem>();
            playerHealth.HealDamage(healAmount);
            Destroy(this.gameObject);
        }
    }
}
