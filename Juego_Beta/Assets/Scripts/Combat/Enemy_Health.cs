using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Health : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth;
    public Slider slider;

    private void Start()
    {
        currentHealth = maxHealth;
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

        else if(currentHealth <= 0)
        {

            Destroy(gameObject);

        }
    }

}
