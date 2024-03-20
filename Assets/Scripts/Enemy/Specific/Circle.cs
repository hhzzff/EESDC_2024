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
        speed_rate = Constant.SpeedDic[info.type];
    }
    void OnDestroy()
    {
        EnemyManager.GetInstance().Hatch(rb.position,EnemyType.Dot,rb.velocity);
    }
    private void Update()
    {
        Step2Place();
        TakeDamage(1);
    }
}
