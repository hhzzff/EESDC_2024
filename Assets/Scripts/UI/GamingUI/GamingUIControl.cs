using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamingUIControl : SingletonMono<GamingUIControl>
{
    public Button defenderButton;
    public bool holdingDefender;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        SetMode();
    }
    void GetInput()
    {
        if (holdingDefender)
        {
            if (Input.GetMouseButtonDown(0))
            {
                holdingDefender = false;
                Debug.Log("Defender dropped");
                TowerManager.GetInstance().CreateTower(TowerType.Defender, Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.up);
            }
            else
            {
                if (Input.GetMouseButtonDown(1))
                {
                    holdingDefender = false;
                }
            }
        }
    }
    void SetMode()
    {

    }
    public void DefenderButtonDown()
    {
        holdingDefender = true;
        Debug.Log("Defender Button Down");
    }
}
