using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ShellData", menuName = "GameData/ShellData", order = 0)]
public class ShellData : ScriptableObject
{
    public int[] damage;
    public float[] speed;
    public float[] explodeRadius;
}
