using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
    public LaserData laserData;
    public int level;
    private float lifeTime = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime > laserData.lifeTime)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("damage?");
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("damage!");
            collision.GetComponent<Enemy>().TakeDamage(laserData.damage[level]);
            Destroy(gameObject);
        }
    }
}
