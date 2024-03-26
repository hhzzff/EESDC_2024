using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ShieldData", menuName = "GameData/ShieldData", order = 0)]

public class ShieldData : ScriptableObject
{
    public float[] chargeSpeed;
    public float radius;
    public int durability;
    public float formTime;
}
