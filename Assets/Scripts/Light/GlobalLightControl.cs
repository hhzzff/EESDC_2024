using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalLightControl : SingletonMono<GlobalLightControl>
{
    public float rotateRadius = 20.0f;
    public float rotateTime = 10.0f;
    public float currentAngle;
    // Start is called before the first frame update
    void Start()
    {
         currentAngle = Mathf.Atan2(transform.position.y, transform.position.x) * Mathf.Rad2Deg;
    }

    // Update is called once per frame
    void Update()
    {
        currentAngle = (currentAngle + Time.deltaTime / rotateTime * 360) % 360;
        transform.position = new Vector3(rotateRadius * Mathf.Cos(currentAngle * Mathf.Deg2Rad), rotateRadius * Mathf.Sin(currentAngle * Mathf.Deg2Rad), 0);
        transform.rotation = Quaternion.AngleAxis(currentAngle + 90, Vector3.forward);
    }
}
