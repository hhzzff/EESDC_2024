using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public enum EnemyType
{
    None,
    Triangle,   //low hp medium speed
    Dot,        //low hp high speed
    Square,     //medium hp medium speed
    Circle,     //medium hp medium speed     split a dot
    Pentagon,   // create a dot
    Rhombus,    // speed up fellows after death
    Star,       // create cloud forward  
    Hexagon,    //  high hp    create two Rhombus when half hp
}
public static class Constant
{
    public static readonly Dictionary<EnemyType, int> HpDic;
    public static readonly Dictionary<EnemyType, float> SpeedDic;

    static Constant()
    {
        int low_hp = 100;
        int medium_hp = 200;
        int high_hp = 300;
        HpDic = new Dictionary<EnemyType, int>
        {
            {EnemyType.Triangle, low_hp },
            {EnemyType.Dot, low_hp},
            {EnemyType.Square,medium_hp},
            {EnemyType.Circle,medium_hp},
            {EnemyType.Pentagon,high_hp},
            {EnemyType.Rhombus,low_hp},
            {EnemyType.Star,medium_hp},
            {EnemyType.Hexagon,high_hp},
        };
        float low_speed = 1;
        float medium_speed = 2;
        float high_speed = 3;
        SpeedDic = new Dictionary<EnemyType, float>
        {
            {EnemyType.Triangle, medium_speed},
            {EnemyType.Dot, high_speed},
            {EnemyType.Square, medium_speed},
            {EnemyType.Circle,medium_speed},
            {EnemyType.Pentagon ,low_speed},
            {EnemyType.Rhombus ,high_speed},
            {EnemyType.Star,high_speed},
            {EnemyType.Hexagon,low_speed},
        };
    }
}