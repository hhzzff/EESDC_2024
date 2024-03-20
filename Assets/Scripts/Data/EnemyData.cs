using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "GameData/EnemyData", order = 0)]
public class EnemyData : ScriptableObject
{
    public int low_hp;
    public int medium_hp;
    public int high_hp;
    public float low_speed;
    public float medium_speed;
    public float high_speed;
    public float speed_decay;
    public float speed_range;
    public float speed_mul;
    public int speed_decay_freq;
}