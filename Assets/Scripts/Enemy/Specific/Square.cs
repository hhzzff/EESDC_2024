using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Square : Enemy
{
    new void Start()
    {
        base.Start();
        info.type=EnemyType.Square;
        info.hp = Constant.HpDic[info.type];
        speed = Constant.SpeedDic[info.type];
    }
    private void Update()
    {
        Step2Place();
    }
}
