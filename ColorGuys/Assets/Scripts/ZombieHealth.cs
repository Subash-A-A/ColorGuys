using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;
    [SerializeField] GameObject zombie;
    [SerializeField] Slider healthBar;
    [SerializeField] float smoothValue = 5f;

    private float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(zombie);
        }
        healthBar.value = Mathf.Lerp(healthBar.value, currentHealth, smoothValue * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
        }
    }
}
