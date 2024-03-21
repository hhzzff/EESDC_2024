using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.PackageManager;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
public enum EnemyType
{
    None,
    Triangle,   //enemyData.low hp enemyData.medium speed
    Dot,        //enemyData.low hp enemyData.high speed
    Square,     //enemyData.medium hp enemyData.medium speed
    Circle,     //enemyData.medium hp enemyData.medium speed     split a dot
    Pentagon,   // create a dot
    Rhombus,    // speed up fel enemyData.lows after death
    Star,       // create cloud forward  
    Hexagon,    //  enemyData.high hp    create two Rhombus when half hp
}
public class Constant : SingletonMono<Constant>
{
    public NormalEnemy dotData;
    public NormalEnemy circleData;
    public NormalEnemy hexagonData;
    public RhombusData rhombusData;
    public NormalEnemy squareData;
    public NormalEnemy triangleData;
    public NormalEnemy pentagonData;
    public NormalEnemy starData;
    public EnemyData enemyData;
    public static Dictionary<EnemyType, int> HpDic;
    public static Dictionary<EnemyType, float> SpeedDic;
    public static int decay_freq;
    public static float speed_decay;
    public static float speed_range;
    public static float speed_mul;

    private void Start()
    {
        HpDic = new Dictionary<EnemyType, int>
        {
            {EnemyType.Triangle, triangleData.hp },
            {EnemyType.Dot, dotData.hp},
            {EnemyType.Square,squareData.hp},
            {EnemyType.Circle,circleData.hp},
            {EnemyType.Pentagon,pentagonData.hp},
            {EnemyType.Rhombus,rhombusData.hp},
            {EnemyType.Star,starData.hp},
            {EnemyType.Hexagon,hexagonData.hp},
        };
        SpeedDic = new Dictionary<EnemyType, float>
        {
            {EnemyType.Triangle, triangleData.speed},
            {EnemyType.Dot, dotData.speed},
            {EnemyType.Square, squareData.speed },
            {EnemyType.Circle,circleData.speed},
            {EnemyType.Pentagon ,pentagonData.speed},
            {EnemyType.Rhombus ,rhombusData.speed},
            {EnemyType.Star,starData.speed},
            {EnemyType.Hexagon,hexagonData.speed},
        };
        speed_decay = enemyData.speed_decay;
        decay_freq = enemyData.decay_freq;
        speed_range = rhombusData.speed_range;
        speed_mul = rhombusData.speed_mul;
        Debug.Log("haha");
    }
}