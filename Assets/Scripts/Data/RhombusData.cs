using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
[CreateAssetMenu(fileName = "RhombusData", menuName = "GameData/RhombusData", order = 0)]
public class RhombusData : ScriptableObject
{
    public int hp;
    public float speed;
    public float speed_decay;
    public float speed_range;
    public float speed_mul;
}