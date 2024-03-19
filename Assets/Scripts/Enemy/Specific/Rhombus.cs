using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Rhombus : Enemy
{
    Rhombus()
    {
        info.type = EnemyType.Rhombus;
        info.hp = Constant.HpDic[info.type];
        speed_rate = Constant.SpeedDic[info.type];
    }
    private void Update()
    {
        Step2Center();
    }
    ~Rhombus()
    {
        // EnemyManager.GetInstance().SpeedUp();
    }
}
