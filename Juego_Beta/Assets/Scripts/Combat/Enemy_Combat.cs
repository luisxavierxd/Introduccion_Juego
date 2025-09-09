using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{

    public float knockbackForce;
    public float stunTime;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public int damage = 5;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioManager.PlaySFX(audioManager.daño);
        collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-damage);
        collision.gameObject.GetComponent<PlayerMovement>().knockback(transform,  knockbackForce, stunTime);
    }

}
