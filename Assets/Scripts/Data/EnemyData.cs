using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "GameData/EnemyData", order = 0)]

public class EnemyData : ScriptableObject
{
    public int decay_freq;
    public float speed_decay;
    public float rhombus_speed_range;
    public float rhombus_speed_mul;
}

