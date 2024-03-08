using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BaseControl : SingletonMono<BaseControl>
{
    public int maxHealth = 100;
    int health;
    int energy;
    int score;
    public int originEnergy;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        energy = originEnergy;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetHealth()
    {
        return health;
    }
    public int GetEnergy()
    {
        return energy;
    }
    public int GetScore()
    {
        return score;
    }
    public void DamageBase(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log("Base damaged!");
    }
}
