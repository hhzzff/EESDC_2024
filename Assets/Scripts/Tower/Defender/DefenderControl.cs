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
    public GameObject battery, bulletFa, laser, predoctionG;
    public Animator batteryAnim;
    public Material SignLightEnableMat, SignLightDisableMat;
    [SerializeField]
    public bool[][] SignLightEnabled = new bool[2][]{
        new bool[9]{false, false, false, false, false, false, false, false, false },
        new bool[9]{false, false, false, false, false, false, false, false, false }};
    public enum State
    {
        Idle,
        Charging,
        Aiming,
        Shooting
    }
    public State currentState = State.Idle;
    public bool inAttackCD;
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
        CheckGlobalLightDirection();
    }
    void SearchForEnemy()
    {
        List<EnemyInfo> enemyList = EnemyManager.GetInstance().GetEnemyList();
        enemyList.Sort((x, y) =>
        {
            if (x.hp > 0 && (x.pos - (Vector2)transform.position).magnitude < (y.pos - (Vector2)transform.position).magnitude)
                return -1;
            if (y.hp > 0 && (y.pos - (Vector2)transform.position).magnitude < (x.pos - (Vector2)transform.position).magnitude)
                return 1;
            return 0;
        });
        // Debug.Log("sort finished");
        foreach (EnemyInfo enemy in enemyList)
        {
            if (enemy.hp > 0)
            {
                // Debug.Log("EnemyPos:" + enemy.pos.x + ", " + enemy.pos.y);
                // Debug.Log("EnemyVel:" + enemy.vel.x + ", " + enemy.vel.y);
                // Debug.Log("CurrentAngle:" + currentAngle);
                float t = (enemy.pos - (Vector2)transform.position).magnitude / laserData.speed;
                predoctionG.transform.position = new Vector2(enemy.pos.x + enemy.vel.x * t, enemy.pos.y + enemy.vel.y * t);
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
        if (Mathf.Abs(angle - currentAngle) <= 3 * Time.deltaTime * defenderData.rotarySpeed)
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
        GameObject bullet = Instantiate(laser, transform.position, Quaternion.AngleAxis(currentAngle + 90, Vector3.forward), bulletFa.transform);
        bullet.GetComponent<Rigidbody2D>().velocity = laserData.speed * (
            Vector2.right * Mathf.Cos(currentAngle * Mathf.Deg2Rad) + Vector2.up * Mathf.Sin(currentAngle * Mathf.Deg2Rad));
        inAttackCD = true;
        yield return new WaitForSeconds(defenderData.firingRate);
        inAttackCD = false;
    }
    void CheckGlobalLightDirection()
    {
        float lightAngle = Mathf.Atan2(
            GlobalLightControl.GetInstance().transform.position.y - transform.position.y,
            GlobalLightControl.GetInstance().transform.position.x - transform.position.x
        ) * Mathf.Rad2Deg;
        lightAngle -= transform.eulerAngles.z;
        while (lightAngle <= -180) lightAngle += 360;
        while (lightAngle > 180) lightAngle -= 360;
        // Debug.Log(lightAngle);
        float minAngle = -67.5f;
        for (int id = 1; id <= 8; id++)
        {
            if (minAngle > 45)
            {
                if (minAngle > 180)
                {
                    if (lightAngle > minAngle - 360 && lightAngle < minAngle - 225)
                        SignLightEnabled[1][id] = true;
                }
                else
                {
                    if (lightAngle > minAngle || lightAngle < minAngle - 225)
                        SignLightEnabled[1][id] = true;
                }
            }
            else
            {
                if (lightAngle > minAngle && lightAngle < minAngle + 135)
                    SignLightEnabled[1][id] = true;
            }
            minAngle += 45;
        }
        for (int i = 1; i <= 8; i++)
        {
            if (SignLightEnabled[0][i] != SignLightEnabled[1][i])
            {
                // Debug.Log("changeVFX" + i.ToString() + " to " + SignLightEnabled[1][i].ToString());
                transform.Find("Base").Find("Base-VFX" + i.ToString()).GetComponent<DefenderLightControl>().
                    ChangeSignLightColor(i, SignLightEnabled[1][i]);
                SignLightEnabled[0][i] = SignLightEnabled[1][i];
            }
            SignLightEnabled[1][i] = false;
        }
    }
}
