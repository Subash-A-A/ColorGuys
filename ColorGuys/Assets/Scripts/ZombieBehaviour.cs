using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform zombie;
    [SerializeField] float speed = 1.5f;
    [SerializeField] float range = 12f;
    [SerializeField] float initialScale = 1f;
    [SerializeField] Animator anim;

    private bool isChasing = false;

    void Update()
    {
        ChasePlayer();
        FlipZombie();
    }

    void ChasePlayer()
    {
        float dist = Vector2.Distance(transform.position, target.position);
        if (dist <= range)
        {
            isChasing = true;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            isChasing = false;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            // Smoothly reduces velocity to 0 if not chasing.
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, 25 * Time.deltaTime);
        }
        anim.SetBool("isChasing", isChasing);
    }

    void FlipZombie()
    {
        Vector3 zombLocalScale = new Vector3(initialScale, initialScale, initialScale);

        if (target.position.x < transform.position.x && isChasing)
        {
            zombLocalScale.x = -initialScale;
        }
        else
        {
            zombLocalScale.x = initialScale;
        }

        zombie.localScale = zombLocalScale;
    }
}
