using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float BulletDamage = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Target")
        {
            Destroy(gameObject);
            HealthSystem zombieHealth = other.transform.gameObject.GetComponent<HealthSystem>();
            zombieHealth.TakeDamage(BulletDamage);
        }
    }

    private void Update()
    {
        Destroy(gameObject, 2f);
    }
}
