using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
[CreateAssetMenu(fileName = "DefenderData", menuName = "GameData/DefenderData", order = 0)]

public class DefenderData : ScriptableObject
{
    public float rotarySpeed;
    public float firingRate;
}
