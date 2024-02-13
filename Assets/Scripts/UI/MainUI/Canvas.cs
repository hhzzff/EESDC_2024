using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class UIMain : MonoBehaviour
{
    public GameObject buttonGamestart;
    public GameObject buttonSetting;
    public GameObject buttonHelp;
    public GameObject buttonExit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStart()
    {

    }
    public void GameSetting(GameObject Settingpanel)
    {
        Settingpanel.SetActive(true);
    }
    public void GameHelp(GameObject Helppanel)
    {
        Helppanel.SetActive(true);
    }
    public void GameExit()
    {

    }
}
