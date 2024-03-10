using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    public EnemyInfo info;
    public float speed_rate;
    public void Step2Center()
    {
        float norm = Mathf.Sqrt(transform.position.x * transform.position.x + transform.position.y * transform.position.y);
        info.vel = new Vector2(-transform.position.x, -transform.position.y) * speed_rate / norm;
        transform.position += Time.deltaTime * new Vector3(info.vel.x, info.vel.y, 0);
        info.pos = new Vector2(transform.position.x, transform.position.y);
    }
    public void TakeDamage(int damage)
    {
        //FlashWhite();
        info.hp -= damage;
        //Debug.Log(info.hp);
    }

    public void Attack(int damage)
    {

    }
}
