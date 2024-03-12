using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBase
{
    public void AddScore(int _score);
    public void AddEnergy(int _energy);
    public void DamageBase(int damage);
}