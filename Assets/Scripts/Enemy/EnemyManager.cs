using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyManager : SingletonMono<EnemyManager>, IEnemyManager
{
    // Start is called before the first frame update
    public Enemy myPrefab;
    public Dictionary<EnemyType, int> hpDic = new Dictionary<EnemyType, int>();
    List<Enemy> enemies = new List<Enemy>();
    Vector3 rightUp;
    Vector3 leftDown;
    float right;
    float left;
    float up;
    float down;
    int cnt = 0;
    void Start()
    {
        rightUp = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        leftDown = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        right = rightUp.x;
        left = leftDown.x;
        up = rightUp.y;
        down = leftDown.y;
        hpDic.Add(EnemyType.Basic, 100);
        //Add.....
    }

    // Update is called once per frame
    void Update()
    {
        CheckHp();
        if (cnt-- == 0)
        {
            GenerateEnemy();
            cnt = 50;
        }

    }
    void GenerateEnemy() //�����µĵ��ˣ�������Time.time��Ŀ������random��ʼ��
    {
        int generateNum = (int)(Time.time % 10) + 1;  //֮���Ǹ���Ϊ���õĵ�������
        float x, y;
        for (int i = 0; i < generateNum; i++)
        {
            x = Random.Range(left - 5, right + 5);
            if (x < left || x > right)
                y = Random.Range(down - 5, up + 5);
            else
            {
                if (Random.value < 0.5f)
                    y = Random.Range(down - 5, down);
                else
                    y = Random.Range(up, up + 5);
            }
            Enemy newEnemy = Instantiate(myPrefab, new Vector3(x, y, 0), Quaternion.identity);
            newEnemy.info.hp = hpDic[EnemyType.Basic];
            newEnemy.info.type = EnemyType.Basic;
            enemies.Add(newEnemy);
        }
    }
    void RemoveEnemy(Enemy enemy)
    {
        if (enemies.Contains(enemy))
        {
            Debug.Log("Enemy Dies");
            enemies.Remove(enemy);
            Destroy(enemy.gameObject);
        }
    }
    void CheckHp()  //����Hp��յĵ���
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            Enemy enemy = enemies[i];
            if (enemy.info.hp <= 0)
            {
                RemoveEnemy(enemy);
            }
        }
    }

    public List<EnemyInfo> GetEnemyList()  //����info
    {
        List<EnemyInfo> enemyInfos = new List<EnemyInfo>();
        foreach (Enemy enemy in enemies)
            enemyInfos.Add(enemy.info);
        return enemyInfos;
    }//��ȡ���������ɵĵ�����Ϣ
}
