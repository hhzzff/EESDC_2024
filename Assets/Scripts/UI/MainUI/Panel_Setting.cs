using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Panel_Setting : MonoBehaviour
{
    public GameObject buttonExit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ExitGame(GameObject settingPanel)
    {
        settingPanel.SetActive(false);
    }

}
