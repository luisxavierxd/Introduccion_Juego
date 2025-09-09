using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public int facingDirection = 1;

    public Rigidbody2D rb;
    public Animator anim;

    private bool isKnockback;

    public Player_Combat player_Combat;

    AudioManager audioManager;
    private bool caminandoSonando = false; // Para controlar el loop

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Slash"))
        {
            player_Combat.Attack();
        }
    }

    void Update()
    {
        if (isKnockback == false)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (horizontal > 0 && transform.localScale.x < 0 ||
                horizontal < 0 && transform.localScale.x > 0)
            {
                Flip();
            }

            anim.SetFloat("horizontal", Mathf.Abs(horizontal));
            anim.SetFloat("vertical", Mathf.Abs(vertical));

            rb.velocity = new Vector2(horizontal, vertical) * speed;

            // Reproducir pasos solo cuando te mueves
            if (rb.velocity != Vector2.zero)
            {
                if (!caminandoSonando)
                {
                    audioManager.PlaySteps();
                    caminandoSonando = true;
                }
            }
            else
            {
                if (caminandoSonando)
                {
                    audioManager.StopSteps();
                    caminandoSonando = false;
                }
            }


        }
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void knockback(Transform enemy, float force, float stunTime)
    {
        isKnockback = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.velocity = direction * force;
        StartCoroutine(KnockbackCounter(stunTime));
    }

    IEnumerator KnockbackCounter(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        rb.velocity = Vector2.zero;
        isKnockback = false;
    }

}
