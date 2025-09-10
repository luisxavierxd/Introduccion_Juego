using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float speed;
    private bool isChasing;

    private Rigidbody2D rb;
    public Transform player;

    [HideInInspector] public bool canMove = true; // controla si el enemigo puede moverse

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Solo moverse si canMove está activado
        if (canMove && isChasing)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
        else if (!canMove)
        {
            rb.velocity = Vector2.zero; // detener al enemigo si no puede moverse
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isChasing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.velocity = Vector2.zero;
            isChasing = false;
        }
    }
}
