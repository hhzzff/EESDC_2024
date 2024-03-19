using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    public EnemyInfo info;
    public float speed_rate;
    public Rigidbody2D rb;
    public bool go2center = true;
    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }
    public void Step2Center()
    {
        float norm = Mathf.Sqrt(transform.position.x * transform.position.x + transform.position.y * transform.position.y);
        if (norm < 1.5)
        {
            rb.velocity = -rb.position * 3;
        }
        else
        {
            rb.AddForce(-rb.position / norm * speed_rate);
            speed_rate *= 0.9875f;
        }
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
    public void Pushed(Vector2 direction,float mul)
    {
        rb.velocity+=direction*mul;
    }
    public void Attack(int damage)
    {

    }
}
