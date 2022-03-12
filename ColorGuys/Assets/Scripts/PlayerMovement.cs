using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Animator anim;
    [SerializeField] KeyCode DanceKey = KeyCode.T;

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isDancing;

    private void Awake()
    {
        isDancing = false;

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {

        // Dance

        if (Input.GetKey(DanceKey) && !isDancing)
        {
            anim.SetBool("isDancing", true);
            isDancing = true;
        }
        else
        {
            anim.SetBool("isDancing", false);
            isDancing = false;
        }

        if (movement.x != 0 || movement.y != 0)
        {
            anim.SetBool("isDancing", false);
            isDancing = false;

            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
