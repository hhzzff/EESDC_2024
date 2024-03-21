using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Triangle : Enemy
{
    new void Start()
    {
        base.Start();
        info.type = EnemyType.Triangle;
        info.hp = Constant.HpDic[info.type];
        speed= Constant.SpeedDic[info.type];
    }
    private void Update()
    {   
        Step2Place();
    }
}
