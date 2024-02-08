using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : SingletonMono<EnemyManager>,IEnemyManager
{
    // Start is called before the first frame update
    List<EnemyBase> enemies = new List<EnemyBase>();
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckHp();
        GenerateEnemies();
        
    }
    public void CheckHp()  //销毁Hp清空的敌人
    {

    }
    public void GenerateEnemies() //增加新的敌人，考虑随Time.time数目递增，random初始化
    {

    }
    public List<EnemyInfo> GetEnemyList()  //返回info
    {
        List<EnemyInfo> enemyInfos = new List<EnemyInfo>();
        foreach(EnemyBase enemy in enemies)
            enemyInfos.Add(enemy.info);
        return enemyInfos;
    }//获取所有已生成的敌人信息
}
