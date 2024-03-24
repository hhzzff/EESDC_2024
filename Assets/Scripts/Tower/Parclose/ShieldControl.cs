using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldControl : MonoBehaviour
{
    public ShieldData shieldData;
    int currentDurability;
    // int current
    void Start()
    {
        currentDurability = shieldData.durability;
    }
    void Uodate()
    {
        if (currentDurability == shieldData.durability)
        {
            FormShield();
        }
    }
    void FormShield()
    {

    }
}
