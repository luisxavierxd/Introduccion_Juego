using UnityEngine;
using UnityEngine.UI;

public class Enemy_Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public Slider slider;

    private Enemy_Combat enemyCombat;
    private Enemy_Movement enemyMovement;

    private void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = currentHealth;

        // Obtener referencias a los scripts que quieres deshabilitar
        enemyCombat = GetComponent<Enemy_Combat>();
        enemyMovement = GetComponent<Enemy_Movement>();
    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        slider.value = currentHealth;

        if (currentHealth <= 0)
        {
            // Deshabilitar scripts de combate y movimiento
            if (enemyCombat != null)
                enemyCombat.enabled = false;

            if (enemyMovement != null)
                enemyMovement.enabled = false;

            // Opcional: desactivar el collider para que no interactúe con el jugador
            Collider2D col = GetComponent<Collider2D>();
            if (col != null)
                col.enabled = false;

            // Opcional: reproducir animación de muerte o sonido
            // Animator anim = GetComponent<Animator>();
            // if(anim != null) anim.SetTrigger("Die");
        }
    }
}
