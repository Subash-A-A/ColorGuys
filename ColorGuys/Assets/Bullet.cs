using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float force = 2f;
    [SerializeField] Rigidbody2D rb;

    private void FixedUpdate()
    {
        rb.AddForce(Vector2.right * force);
    }

    private void Update()
    {
        Destroy(gameObject, 2f);
    }
}
