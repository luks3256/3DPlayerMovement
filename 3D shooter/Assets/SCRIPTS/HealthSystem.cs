using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private int health;
    private int healthMax;
    public HealthSystem(int healthMax) {
        this.healthMax = healthMax;
        health = healthMax;
    }
    public int GetHealth() {
        return health;
    }
    public void Damage(int damgeAmount) {
        health -= damgeAmount;
        if (healthMax < 0) health = 0;
    }
    public void Heal(int healAmount) {
        health += healAmount;
        if (health > healthMax) health = healthMax;
    }

}
