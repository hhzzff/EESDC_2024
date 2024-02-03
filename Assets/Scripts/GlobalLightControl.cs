using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalLightControl : MonoBehaviour
{
    public float rotateRadius = 20.0f;
    public float rotateTime = 10.0f;
    public float currentAngle;
    // Start is called before the first frame update
    void Start()
    {
         currentAngle = Mathf.Atan2(transform.position.y, transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        currentAngle = (currentAngle + Time.deltaTime / rotateTime * 2 * Mathf.PI) % (2 * Mathf.PI);
        transform.position = new Vector3(rotateRadius * Mathf.Cos(currentAngle), rotateRadius * Mathf.Sin(currentAngle), 0);
        transform.rotation = Quaternion.AngleAxis(currentAngle * Mathf.Rad2Deg + 90, Vector3.forward);
    }
}
