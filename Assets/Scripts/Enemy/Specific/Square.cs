using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Square : Enemy
{
    Square()
    {
        info.type = EnemyType.Square;
        speed_rate = Constant.SpeedDic[info.type];
        info.hp = Constant.HpDic[info.type];
    }
    private void Update()
    {
        Step2Place();
    }
}
