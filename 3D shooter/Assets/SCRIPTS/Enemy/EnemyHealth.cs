using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IDamageble
{
    [SerializeField]
    private EnemyStats enemyStats;
    [SerializeField]
    private Slider healthbarSlider;
    [SerializeField]
    private Image healthbarFillImage;
    [SerializeField]
    private Color maxHealthColor;
    [SerializeField]
    private Color zeroHealthColor;
    private int currentHealth;

    private void Start()
    {
        currentHealth = enemyStats.maxHealth;
        SetHealthbarUI();
    }

    public void DealDamage(int damage)
    {
        currentHealth -= damage;
        CheckIfDead();
        SetHealthbarUI();
    }
    private void CheckIfDead() {
        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    }
    private void SetHealthbarUI() {
        float health = (float)currentHealth / enemyStats.maxHealth;
        healthbarSlider.value = health;
        healthbarFillImage.color = Color.Lerp(zeroHealthColor,maxHealthColor,health);
    }
}
