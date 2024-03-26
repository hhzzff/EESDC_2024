using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    public Rigidbody2D rb;
    public Animator ani;
    public EnemyInfo info;

    public Vector2 target;
    public float speed;
    public int decay_cnt;

    private BaseControl baseC;
    public int damage;
    public int damage_cnt;
    public int score;
    public int energy;

    public bool givenBirth = false;
    public bool attackMode = false;
    protected void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        rb.angularVelocity = 128;
        baseC =BaseControl.GetInstance();
        decay_cnt = Constant.decay_cnt;
        damage_cnt=Constant.damage_cnt;
        ani = GetComponent<Animator>();
    }
    public void Step2Place()
    {
        if (!attackMode)
        {
            decay_cnt--;
            if (decay_cnt == 0)
            {
                speed *= Constant.speed_decay;
                decay_cnt = Constant.decay_cnt;
            }
            Vector2 r = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
            float norm = r.magnitude;
            if (rb.position.magnitude > 5f | norm < 0.5f)
            {
                SetTarget(new Vector2(0, 0));
            }
            rb.AddForce(r / norm * speed);
        }
        else
        {
            damage_cnt--;
            if(damage_cnt==0)
            {
                Attack();
                damage_cnt = Constant.damage_cnt;
            }
        }
    }
    public void SetTarget(Vector2 place)
    {
        target = place;
    }
    public void UpdateInfo()
    {
        if(!rb)
        {
            rb=GetComponent<Rigidbody2D>();
        }
        info.vel = rb.velocity;
        info.pos = rb.position;
    }
    public void TakeDamage(int damage)
    {
        ani.SetTrigger("Injured");
        info.hp -= damage;
    }
    public void Pushed(Vector2 direction, float val)
    {
        rb.AddForce(direction * val);
        rb.velocity += direction * val;
    }
    public void Attack()
    {
        baseC.DamageBase(damage);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Base"))
        {
            attackMode = true;
            speed *= 0f;
            rb.velocity *= 0f; 
        }
    }
}
