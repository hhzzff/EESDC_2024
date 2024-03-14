using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class DefenderControl : MonoBehaviour
{
    public DefenderData defenderData;
    public LaserData laserData;
    public float currentAngle;
    public GameObject battery, bulletFa, predoctionG;
    public GameObject[] laser;
    public Animator batteryAnim;
    public enum State
    {
        Idle, Charging, Aiming, Shooting
    }
    public State currentState = State.Idle;
    public bool inAttackCD;
    public int chargingState;
    // Start is called before the first frame update
    void Start()
    {
        battery = transform.Find("Battery").gameObject;
        bulletFa = GameObject.Find("Bullet");
        batteryAnim = battery.GetComponent<Animator>();
        currentAngle = transform.eulerAngles.z + battery.transform.eulerAngles.z + 90;
    }

    // Update is called once per frame
    void Update()
    {
        SearchForEnemy();
        // Debug.Log(chargingState);
    }
    void SearchForEnemy()
    {
        List<EnemyInfo> enemyList = EnemyManager.GetInstance().GetEnemyList();
        enemyList.Sort((x, y) =>
        {
            if (x.hp > 0 && x.pos.magnitude != 0 && (x.pos - (Vector2)transform.position).magnitude < (y.pos - (Vector2)transform.position).magnitude)
                return -1;
            if (y.hp > 0 && y.pos.magnitude != 0 && (y.pos - (Vector2)transform.position).magnitude < (x.pos - (Vector2)transform.position).magnitude)
                return 1;
            return 0;
        });
        //Debug.Log("sort finished");
        foreach (EnemyInfo enemy in enemyList)
        {
            if (enemy.hp > 0)
            {
                // Debug.Log("EnemyPos:" + enemy.pos.x + ", " + enemy.pos.y);
                // Debug.Log("EnemyVel:" + enemy.vel.x + ", " + enemy.vel.y);
                // Debug.Log("CurrentAngle:" + currentAngle);
                float t = (enemy.pos - (Vector2)transform.position).magnitude / laserData.speed[GetLaserLevel()];
                // predoctionG.transform.position = new Vector2(enemy.pos.x + enemy.vel.x * t, enemy.pos.y + enemy.vel.y * t);
                RotateBatteryTo(Mathf.Atan2(
                    enemy.pos.y + enemy.vel.y * t - transform.position.y,
                    enemy.pos.x + enemy.vel.x * t - transform.position.x
                    ) * Mathf.Rad2Deg);
                break;
            }
        }
    }
    void RotateBatteryTo(float angle)
    {
        while (angle - currentAngle > 180)
            angle -= 360;
        while (currentAngle - angle > 180)
            angle += 360;
        // Debug.Log("current " + currentAngle.ToString() + " rotate to " + angle);
        if (Mathf.Abs(angle - currentAngle) <= Time.deltaTime * defenderData.rotarySpeed)
        {
            if (Mathf.Abs(angle - currentAngle) <= Time.deltaTime * defenderData.rotarySpeed)
            {
                currentAngle = angle;
            }
            currentState = State.Shooting;
            battery.transform.rotation = Quaternion.AngleAxis(currentAngle - 90, Vector3.forward);
            TryAttack();
            return;
        }
        currentState = State.Aiming;
        if (angle > currentAngle)
            currentAngle = (currentAngle + Time.deltaTime * defenderData.rotarySpeed) % 360;
        if (angle < currentAngle)
            currentAngle = (currentAngle - Time.deltaTime * defenderData.rotarySpeed) % 360;
        battery.transform.rotation = Quaternion.AngleAxis(currentAngle - 90, Vector3.forward);
    }
    void TryAttack()
    {
        if (!inAttackCD)
            StartCoroutine(Attack());
    }
    IEnumerator Attack()
    {
        batteryAnim.SetTrigger("Shoot");
        GameObject bullet = Instantiate(laser[GetLaserLevel()], transform.position, Quaternion.AngleAxis(currentAngle + 90, Vector3.forward), bulletFa.transform);
        bullet.GetComponent<Rigidbody2D>().velocity = laserData.speed[GetLaserLevel()] * (
            Vector2.right * Mathf.Cos(currentAngle * Mathf.Deg2Rad) + Vector2.up * Mathf.Sin(currentAngle * Mathf.Deg2Rad));
        inAttackCD = true;
        yield return new WaitForSeconds(defenderData.firingRate);
        inAttackCD = false;
    }
    int GetLaserLevel()
    {
        if (chargingState <= 2)
            return 0;
        if (chargingState <= 5)
            return 1;
        return 2;
    }
    public void SwitchChargingState(int num)
    {
        chargingState += num;
    }
}
