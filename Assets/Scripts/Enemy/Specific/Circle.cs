using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Circle : Enemy
{
    new void Start()
    {
        base.Start();
        info.type = EnemyType.Circle;
        info.hp = Constant.HpDic[info.type];
        speed = Constant.SpeedDic[info.type];
    }
    void OnDestroy()
    {
        EnemyManager.GetInstance().Hatch(rb.position, EnemyType.Dot);
    }
    private void Update()
    {
        Step2Place();
        TakeDamage(1);
    }
}
