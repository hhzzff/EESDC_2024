using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour,IEnemy
{
    public EnemyInfo info;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Step2Center()  //向中心行进对位置等更新
    {

    }
    public void TakeDamage(int damage)
    {
            info.hp -= damage;  //检查在manager里进行？
        //需要加上白光闪烁效果
    }
    
}
