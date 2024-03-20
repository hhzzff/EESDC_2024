using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class EnemyManager : SingletonMono<EnemyManager>, IEnemyManager
{
    public Triangle triangle;
    public Circle circle;
    public Dot dot;
    public Square square;

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
    }

    // Update is called once per frame
    void Update()
    {
        CheckHp();
        if (cnt-- == 0)
        {
            GenerateEnemy();
            cnt = 100;
        }

    }
    void GenerateEnemy()
    {
        int generateNum = (int)(Time.time % 10) + 1;
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
            // should be random
            int randomValue = Random.Range(0, 4); // ����0��3֮����������
            Enemy newEnemy;
            switch (randomValue)
            {
                case 0:
                    newEnemy = Instantiate(triangle, new Vector3(x, y, 0), Quaternion.identity);
                    break;
                case 1:
                    newEnemy = Instantiate(dot, new Vector3(x, y, 0), Quaternion.identity);
                    break;
                case 2:
                    newEnemy = Instantiate(square, new Vector3(x, y, 0), Quaternion.identity);
                    break;
                case 3:
                    newEnemy = Instantiate(circle, new Vector3(x, y, 0), Quaternion.identity);
                    break;
                default:
                    newEnemy = null;
                    break;

            }
            enemies.Add(newEnemy);
        }
    }
    void RemoveEnemy(Enemy enemy)
    {
        if (enemies.Contains(enemy))
        {
            // Debug.Log("Enemy Dies");
            enemies.Remove(enemy);
            Destroy(enemy.gameObject);
        }
    }
    void CheckHp()
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
    public List<EnemyInfo> GetEnemyList()
    {
        List<EnemyInfo> enemyInfos = new List<EnemyInfo>();
        foreach (Enemy enemy in enemies)
        {
            enemy.UpdateInfo();
            enemyInfos.Add(enemy.info);
        }
        return enemyInfos;
    }
    public void Summon()
    {

    }
<<<<<<< HEAD
    public async void Hatch(Vector2 pos, EnemyType type)
    {
        if (type == EnemyType.Dot)
        {
            Enemy newEnemy = Instantiate(dot, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
=======
    public void Hatch(Vector2 pos,EnemyType type,Vector2 vel)
    {
        if (type == EnemyType.Dot)
        {
            Dot newEnemy = Instantiate(dot, new Vector3(pos.x, pos.y, 0), Quaternion.identity).GetComponent<Dot>();
            Vector2 direction = new Vector2(Random.value,Random.value);
            float val = 5;
            newEnemy.SetTarget(direction * val);
            Debug.Log("direction is "+ newEnemy.target);
>>>>>>> ae0913a825937bc2818ff7ebede866925d286d15
            enemies.Add(newEnemy);
        }
    }
}
