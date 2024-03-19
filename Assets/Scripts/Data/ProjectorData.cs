using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectorData", menuName = "GameData/ProjectorData", order = 0)]
public class ProjectorData : ScriptableObject
{
    public float rotarySpeed;
    public float firingRate;
}
