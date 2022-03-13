using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float BulletDamage = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Target")
        {
            Destroy(gameObject);
            ZombieHealth zh = other.transform.gameObject.GetComponent<ZombieHealth>();
            zh.TakeDamage(BulletDamage);
        }
    }

    private void Update()
    {
        Destroy(gameObject, 2f);
    }
}
