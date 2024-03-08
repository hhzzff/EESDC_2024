using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : SingletonMono<PlayerControl>
{
    public bool holdingDefender, holdingBeacon;
    public GameObject defenderUI, beaconUI;
    public GameObject holdingObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();

    }
    void GetInput()
    {
        if (holdingDefender)
        {
            if (Input.GetMouseButtonDown(0))
            {
                holdingDefender = false;
                Destroy(holdingObject);
                Debug.Log("Defender dropped");
                TowerManager.GetInstance().CreateTower(TowerType.Defender, Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.up);
            }
            else
            {
                if (!holdingObject)
                {
                    holdingObject = Instantiate(defenderUI);
                }
                holdingObject.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (Input.GetMouseButtonDown(1))
                {
                    holdingDefender = false;
                    Destroy(holdingObject);
                }
            }
        }
        if (holdingBeacon)
        {
            if (Input.GetMouseButtonDown(0))
            {
                holdingBeacon = false;
                Destroy(holdingObject);
                Debug.Log("Beacon dropped");
                TowerManager.GetInstance().CreateTower(TowerType.Beacon, Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.up);
            }
            else
            {
                if (!holdingObject)
                {
                    holdingObject = Instantiate(beaconUI);
                }
                holdingObject.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (Input.GetMouseButtonDown(1))
                {
                    holdingBeacon = false;
                    Destroy(holdingObject);
                }
            }
        }
    }
}
