using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Square : Enemy
{
    Square()
    {
        info.type=EnemyType.Square;
        info.hp = Constant.HpDic[info.type];
        speed_rate = Constant.SpeedDic[info.type];
    }
    private void Update()
    {
        Step2Center();
    }
}
