using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Triangle : Enemy
{
    Triangle()
    {
        info.type = EnemyType.Triangle;
        info.hp = Constant.HpDic[info.type];
        speed_rate= Constant.SpeedDic[info.type];
    }
    private void Update()
    {   
        Step2Place();
    }
}
