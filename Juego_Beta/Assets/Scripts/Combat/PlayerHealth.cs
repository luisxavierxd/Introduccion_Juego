using System.Collections;
using System.Collections.Generic;
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
        currentHealth += amount;
        slider.value = currentHealth;
        if (currentHealth <= 0) {

            gameObject.SetActive(false);
        }

    }
}
