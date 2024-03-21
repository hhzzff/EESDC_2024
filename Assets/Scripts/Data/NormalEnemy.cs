using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
[CreateAssetMenu(fileName = "NormalEnemyData", menuName = "GameData/NormalEnemyData", order = 0)]
public class NormalEnemy : ScriptableObject
{
    public int hp;
    public float speed;
    public float speed_decay;
}