using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseControl : SingletonMono<BaseControl>
{
    public int maxHealth = 100;
    int health;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetHealth()
    {
        return health;
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
