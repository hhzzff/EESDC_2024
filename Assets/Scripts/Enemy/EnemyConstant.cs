using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public enum EnemyType
{
    None,
    Triangle,   //enemyData.low hp enemyData.medium speed
    Dot,        //enemyData.low hp enemyData.high speed
    Square,     //enemyData.medium hp enemyData.medium speed
    Circle,     //enemyData.medium hp enemyData.medium speed     split a dot
    Pentagon,   // create a dot
    Rhombus,    // speed up felenemyData.lows after death
    Star,       // create cloud forward  
    Hexagon,    //  enemyData.high hp    create two Rhombus when half hp
}
public class Constant : SingletonMono<Constant>
{
    public static Dictionary<EnemyType, int> HpDic;
    public static Dictionary<EnemyType, float> SpeedDic;
    public EnemyData enemyData;

    private void Start()
    {
        HpDic = new Dictionary<EnemyType, int>
        {
            {EnemyType.Triangle, enemyData.low_hp },
            {EnemyType.Dot, enemyData.low_hp},
            {EnemyType.Square,enemyData.medium_hp},
            {EnemyType.Circle,enemyData.medium_hp},
            {EnemyType.Pentagon,enemyData.high_hp},
            {EnemyType.Rhombus,enemyData.low_hp},
            {EnemyType.Star,enemyData.medium_hp},
            {EnemyType.Hexagon,enemyData.high_hp},
        };
        SpeedDic = new Dictionary<EnemyType, float>
        {
            {EnemyType.Triangle, enemyData.medium_speed},
            {EnemyType.Dot, enemyData.high_speed},
            {EnemyType.Square, enemyData.medium_speed },
            {EnemyType.Circle,enemyData.medium_speed},
            {EnemyType.Pentagon ,enemyData.low_speed},
            {EnemyType.Rhombus ,enemyData.high_speed},
            {EnemyType.Star,enemyData.high_speed},
            {EnemyType.Hexagon,enemyData.low_speed},
        };
    }
}