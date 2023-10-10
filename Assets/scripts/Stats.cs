using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{

    public int health;
    public int maxHealth = 100;

    public Image healthBar;

    void Start()
    {
        health = maxHealth;
        healthBar.fillAmount = health / maxHealth;
    }

    public void DecreaseHealth(int delta)
    {
        health -= delta;
        if(health < 0)
        {
            health = 0;
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        healthBar.fillAmount = (float)health / (float)maxHealth;
    }

    public bool IsAlive()
    {
        return health > 0;
    }
}
