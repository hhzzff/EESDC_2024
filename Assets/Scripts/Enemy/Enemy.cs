using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    public EnemyInfo info;
    public float speed;
    public Rigidbody2D rb;
    public Vector2 target;
    public int cnt;
    protected void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        cnt = Constant.decay_freq;
    }
    public void Step2Place()
    {
        cnt--;
        if(cnt==0)
        {
            speed *= Constant.speed_decay;
            cnt = Constant.decay_freq;
        }
        if (rb.position.magnitude < 0.2)
        {
            rb.velocity *= 0f;
            return;
        }
        Vector2 r = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
        float norm = r.magnitude;
        if (rb.position.magnitude>2f|norm<0.5f) 
        {
            SetTarget(new Vector2(0, 0)); 
        }
        if (speed < 0.2)
            speed = 0.2f;
        rb.AddForce(r/ norm * speed);
    }
    public void SetTarget(Vector2 place)
    {
        target = place;
    }
    public void UpdateInfo()
    {
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
      // Debug.Log("Trigger with obstacle detected!");
    }
}
