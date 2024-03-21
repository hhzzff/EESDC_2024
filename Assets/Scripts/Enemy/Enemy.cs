using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    public EnemyInfo info;
    public float speed_rate;
    public Rigidbody2D rb;
    public Vector2 target;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = new Vector2(0, 0);
    }
    public void Step2Place()
    {
        // Debug.Log("Target is "+target.x);
        Vector2 r = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
        float norm = Mathf.Sqrt(r.x * r.x + r.y * r.y);
        if (norm < 1.5)
        {
            rb.velocity = r * 3;
        }
        else
        {
            rb.AddForce(r / norm * speed_rate);
            speed_rate *= 0.9875f;
        }
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
