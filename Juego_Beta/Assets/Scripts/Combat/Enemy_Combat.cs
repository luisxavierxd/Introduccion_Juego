using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{

    public float knockbackForce;
    public float stunTime;

    public int damage = 5;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-damage);
        collision.gameObject.GetComponent<PlayerMovement>().knockback(transform,  knockbackForce, stunTime);
    }

}
