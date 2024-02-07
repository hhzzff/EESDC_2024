using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyType{
    None,
    Basic
}
public struct EnemyInfo{
    Vector2 pos;
    Vector2 vel;
    int hp;
    EnemyType type;
}
public interface IEnemy{//敌人基类继承自此接口
    public void TakeDamage(int damage);//用于对敌人造成伤害
}
public interface IEnemyManager{//敌人管理器继承自此接口
    public List<EnemyInfo> GetEnemyList();//获取所有已生成的敌人信息
}