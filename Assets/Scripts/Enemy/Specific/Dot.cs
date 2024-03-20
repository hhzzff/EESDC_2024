using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Dot : Enemy
{
    Dot()
    {
        info.type=EnemyType.Dot;
        info.hp = Constant.HpDic[info.type];
        speed_rate = Constant.SpeedDic[info.type];
    }
    private void Update()
    {
        Step2Place();
    }
}
