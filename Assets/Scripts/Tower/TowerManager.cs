using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TowerType
{
    None,
    Defender,
    Beacon,
}
public class TowerManager : SingletonMono<TowerManager>
{
    public GameObject towerPa, defender, beacon;
    // Start is called before the first frame update
    void Start()
    {
        towerPa = GameObject.Find("tower");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CreateTower(TowerType towerType, Vector2 pos, Vector2 dir)
    {
        switch (towerType)
        {
            case TowerType.Defender:
                Instantiate(defender, pos, Quaternion.AngleAxis(Vector2.SignedAngle(Vector2.right, dir), Vector3.forward), towerPa.transform);
                break;
            case TowerType.Beacon:
                Instantiate(beacon, pos, Quaternion.AngleAxis(Vector2.SignedAngle(Vector2.right, dir), Vector3.forward), towerPa.transform);
                break;
        }
    }
}
