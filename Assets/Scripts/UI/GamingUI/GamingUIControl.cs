using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamingUIControl : SingletonMono<GamingUIControl>
{
    public Button defenderButton;
    public Slider healthBar;
    public TextMeshProUGUI healthText, energyText, scoreText;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = transform.Find("BaseHealth").GetComponent<Slider>();
        healthText = transform.Find("BaseHealth").Find("BaseHealthText").GetComponent<TextMeshProUGUI>();
        energyText = transform.Find("EnergyImg").Find("EnergyText").GetComponent<TextMeshProUGUI>();
        scoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
        UpdateEnergy();
        UpdateScore();
    }
    void UpdateHealth()
    {
        healthBar.value = BaseControl.GetInstance().GetHealth() / BaseControl.GetInstance().maxHealth;
        healthText.text = BaseControl.GetInstance().GetHealth().ToString() + " / " + BaseControl.GetInstance().maxHealth.ToString();
    }
    void UpdateEnergy()
    {
        energyText.text = BaseControl.GetInstance().GetEnergy().ToString();
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + BaseControl.GetInstance().GetScore();
    }
    public void DefenderButtonDown()
    {
        PlayerControl.GetInstance().holdingDefender = true;
        Debug.Log("Defender Button Down");
    }
    public void BeaconButtonDown()
    {
        PlayerControl.GetInstance().holdingBeacon = true;
        Debug.Log("Beacon Button Down");
    }
}
