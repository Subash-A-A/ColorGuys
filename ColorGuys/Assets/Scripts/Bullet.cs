using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Target")
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Destroy(gameObject, 2f);
    }
}
