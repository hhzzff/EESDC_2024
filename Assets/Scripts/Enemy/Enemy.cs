using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    public EnemyInfo info;
    private Renderer renderer = new Renderer();
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }
    void Update()
    {
        Step2Center();
        // TakeDamage(1);
    }
    void Step2Center()
    {
        float norm = Mathf.Sqrt(transform.position.x * transform.position.x + transform.position.y * transform.position.y);
        info.vel = new Vector2(-transform.position.x, -transform.position.y) / norm;
        transform.position += Time.deltaTime * new Vector3(info.vel.x, info.vel.y, 0);
        info.pos = new Vector2(transform.position.x, transform.position.y);
    }
    public void TakeDamage(int damage)
    {
        FlashWhite();
        info.hp -= damage; //hp����manager���
        // Debug.Log(info.hp);

    }
    private IEnumerator FlashWhite()
    {
        renderer.material.color = Color.white;
        yield return new WaitForSeconds(1f);
        renderer.material.color = Color.black;
    }

}
