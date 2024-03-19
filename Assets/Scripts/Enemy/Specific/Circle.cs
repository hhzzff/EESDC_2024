using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Circle : Enemy
{
    Circle()
    {
        info.type=EnemyType.Circle;
        info.hp = Constant.HpDic[info.type];
        Debug.Log(Constant.HpDic[info.type]);
        speed_rate = Constant.SpeedDic[info.type];
    }
    ~Circle()
    {
        EnemyManager.GetInstance().Hatch(rb.position,EnemyType.Dot);
    }
    private void Update()
    {
        Step2Center();
    }
}
