using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class DefenderControl : MonoBehaviour
{
    public float rotateSpeed = 135f;
    public float currentAngle;
    public GameObject battery;
    public Material SignLightEnableMat, SignLightDisableMat;
    private bool[] SignLightEnabled = new bool[9]{false, false, false, false, false, false, false, false, false};
    // Start is called before the first frame update
    void Start()
    {
        battery = transform.Find("Battery").gameObject;
        currentAngle = battery.transform.rotation.z + 90;
    }

    // Update is called once per frame
    void Update()
    {
        RotateBattery();
        CheckGlobalLightDirection();
    }
    void RotateBattery(){
        if(Input.GetKey(KeyCode.LeftArrow))
            currentAngle = (currentAngle + Time.deltaTime * rotateSpeed) % 360;
        if(Input.GetKey(KeyCode.RightArrow))
            currentAngle = (currentAngle - Time.deltaTime * rotateSpeed) % 360;
        battery.transform.rotation = Quaternion.AngleAxis(currentAngle - 90, Vector3.forward);
    }
    void CheckGlobalLightDirection(){
        float lightAngle = Mathf.Atan2(
            GlobalLightControl.GetInstance().transform.position.y - transform.position.y,
            GlobalLightControl.GetInstance().transform.position.x - transform.position.x
        ) * Mathf.Rad2Deg;
        lightAngle -= transform.eulerAngles.z;
        while(lightAngle <= -180) lightAngle += 360;
        while(lightAngle > 180) lightAngle -= 360;
        Debug.Log(lightAngle);
        float minAngle = -67.5f;
        int id = 1;
        for(int i = 1;i <= 8;i++)
            SignLightEnabled[i] = false;
        while(id <= 8){
            if(minAngle > 45){
                if(minAngle > 180){
                    if(lightAngle > minAngle - 360 && lightAngle < minAngle - 225)
                        SignLightEnabled[id] = true;
                }else
                    if(lightAngle > minAngle || lightAngle < minAngle - 225)
                        SignLightEnabled[id] = true;
            }else
                if(lightAngle > minAngle && lightAngle < minAngle + 135)
                    SignLightEnabled[id] = true;
            id++;
            minAngle += 45;
        }
        for(int i = 1;i <= 8;i++)
            if(SignLightEnabled[i])
                ChangeSignLightColor(i, true);
            else
                ChangeSignLightColor(i, false);
    }
    void ChangeSignLightColor(int childId, bool enabled){
        if(enabled)
            transform.Find("Base").Find("Base-VFX" + childId.ToString()).GetComponent<SpriteRenderer>().material = SignLightEnableMat;
        else
            transform.Find("Base").Find("Base-VFX" + childId.ToString()).GetComponent<SpriteRenderer>().material = SignLightDisableMat;
    }
}
