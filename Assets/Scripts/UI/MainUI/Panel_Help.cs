using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Help : MonoBehaviour
{
    public GameObject buttonExit;
    public GameObject panelGamestart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ExitPanel(GameObject helpPanel)
    {
        helpPanel.SetActive(false);
        panelGamestart.SetActive(true);
    }
}
