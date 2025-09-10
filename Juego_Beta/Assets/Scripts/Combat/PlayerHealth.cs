using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public Slider slider;

    private void Start()
    {
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        slider.value = currentHealth;

        if (currentHealth <= 0)
        {
            // Mostrar pantalla de Game Over
            FindObjectOfType<GameOverScreen>().ShowGameOver();

  
            // Opcional: también detener combates u otras acciones
            Enemy_Combat[] combates = FindObjectsOfType<Enemy_Combat>();
            foreach (Enemy_Combat combate in combates)
            {
                combate.enabled = false;
            }

            Enemy_Movement[] enemigos = FindObjectsOfType<Enemy_Movement>();
            foreach (Enemy_Movement enemigo in enemigos)
            {
                enemigo.canMove = false;
            }

        }
    }
}
