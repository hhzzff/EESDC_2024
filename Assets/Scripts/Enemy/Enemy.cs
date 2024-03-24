using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    public EnemyInfo info;
    //�ƶ��й�
    public Rigidbody2D rb;
    public Vector2 target;
    public int cnt;
    public float speed;
    //�˺�
    public int damage;
    private BaseControl baseC;
    //����
    public int score;
    public int energy;
    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        baseC = BaseControl.GetInstance();
        cnt = Constant.decay_freq;
    }
    public void Step2Place()
    {
        cnt--;
        if (cnt == 0)
        {
            speed *= Constant.speed_decay;
            cnt = Constant.decay_freq;
        }
        //if (rb.position.magnitude < 0.2)
        //{
        //    rb.velocity *= 0f;
        //    baseC.DamageBase(damage);
        //    return;
        //}
        Vector2 r = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
        float norm = r.magnitude;
        if (rb.position.magnitude > 5f | norm < 0.5f)
        {
            SetTarget(new Vector2(0, 0));
        }
        //TODO
        //if (speed < 0.2)
        //    speed = 0.2f;
        rb.AddForce(r / norm * speed);
        rb.AddTorque(norm / speed);
    }
    public void SetTarget(Vector2 place)
    {
        target = place;
    }
    public void UpdateInfo()
    {
        if (!rb)
            rb = GetComponent<Rigidbody2D>();
        info.vel = rb.velocity;
        info.pos = rb.position;
    }
    public void TakeDamage(int damage)
    {
        //FlashWhite();
        info.hp -= damage;
        //Debug.Log(info.hp);
    }
    public void Pushed(Vector2 direction, float val)
    {
        rb.AddForce(direction * val);
        rb.velocity += direction * val;
    }
    public void Attack(int damage)
    {

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Base"))
        {
            speed *= 0f;
            rb.velocity *= 0f;
        }
    }
}
