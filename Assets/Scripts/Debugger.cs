using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : SingletonMono<Debugger>
{
    int cnt = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cnt-- <= 0)
        {
            cnt = 30;
            BaseControl.GetInstance().DamageBase(1);
        }
    }
}
