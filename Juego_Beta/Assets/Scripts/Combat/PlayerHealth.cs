
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
        int newHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        if (newHealth != currentHealth)
        {
            currentHealth = newHealth;
            slider.value = currentHealth;
        }
        if (currentHealth <= 0) {

            FindObjectOfType<GameOverScreen>().GOSetup();
        }

    }
}
