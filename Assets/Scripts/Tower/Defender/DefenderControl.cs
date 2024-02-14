using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class DefenderControl : MonoBehaviour
{
    public float rotateSpeed = 135f;
    public float currentAngle;
    public GameObject battery, bulletFa, laser;
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
    public float attackCDMax = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        battery = transform.Find("Battery").gameObject;
        bulletFa = GameObject.Find("Bullet");
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
        foreach (EnemyInfo enemy in enemyList)
        {
            if (enemy.hp > 0)
            {
                float t = (enemy.pos - (Vector2)transform.position).magnitude / ParaDefine.GetInstance().laserSpeed;
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
        if (Mathf.Abs(angle - currentAngle) <= Time.deltaTime * rotateSpeed)
        {
            currentAngle = angle;
            currentState = State.Shooting;
            battery.transform.rotation = Quaternion.AngleAxis(currentAngle - 90, Vector3.forward);
            TryAttack();
            return;
        }
        currentState = State.Aiming;
        if (angle > currentAngle)
            currentAngle = (currentAngle + Time.deltaTime * rotateSpeed) % 360;
        if (angle < currentAngle)
            currentAngle = (currentAngle - Time.deltaTime * rotateSpeed) % 360;
        battery.transform.rotation = Quaternion.AngleAxis(currentAngle - 90, Vector3.forward);
    }
    void TryAttack()
    {
        if (!inAttackCD)
            StartCoroutine(Attack());
    }
    IEnumerator Attack()
    {

        GameObject bullet = Instantiate(laser, transform.position, Quaternion.identity, bulletFa.transform);
        bullet.GetComponent<Rigidbody2D>().velocity = ParaDefine.GetInstance().laserSpeed * (
            Vector2.right * Mathf.Cos(currentAngle) + Vector2.up * Mathf.Sin(currentAngle));
        inAttackCD = true;
        yield return new WaitForSeconds(attackCDMax);
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
