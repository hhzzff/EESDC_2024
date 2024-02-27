using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
[CreateAssetMenu(fileName = "LaserData", menuName = "GameData/LaserData", order = 0)]
public class LaserData : ScriptableObject
{
    public int[] damage;
    public float[] speed;
    public float lifeTime;
}
