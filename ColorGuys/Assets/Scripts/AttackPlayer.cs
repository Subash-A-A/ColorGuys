using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField] float zombieDamage = 10f;
    [SerializeField] float zombieDot = 0.5f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            HealthSystem playerHealth = other.transform.gameObject.GetComponent<HealthSystem>();
            playerHealth.TakeDamage(zombieDamage);
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            HealthSystem playerHealth = other.transform.gameObject.GetComponent<HealthSystem>();
            playerHealth.TakeDamage(zombieDot);
        }
    }
}
