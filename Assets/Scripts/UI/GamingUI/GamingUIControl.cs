using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamingUIControl : SingletonMono<GamingUIControl>
{
    public Button defenderButton;
    public Slider healthBar;
    public TextMeshProUGUI healthText, energyText, scoreText;
    public AnimationCurve animationCurve;
    public float animationTime;
    public GameObject energyIcon;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = transform.Find("BaseHealth").GetComponent<Slider>();
        healthText = transform.Find("BaseHealth").Find("BaseHealthText").GetComponent<TextMeshProUGUI>();
        energyIcon = transform.Find("Energy").Find("EnergyIcon").gameObject;
        energyText = transform.Find("Energy").Find("EnergyText").GetComponent<TextMeshProUGUI>();
        scoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateHealth()
    {
        healthBar.value = BaseControl.GetInstance().GetHealth() / BaseControl.GetInstance().maxHealth;
        healthText.text = BaseControl.GetInstance().GetHealth().ToString() + " / " + BaseControl.GetInstance().maxHealth.ToString();
    }
    public void UpdateEnergy()
    {
        StartCoroutine(EnergyAnim(energyIcon, animationCurve));
        energyText.text = BaseControl.GetInstance().GetEnergy().ToString();
    }
    IEnumerator EnergyAnim(GameObject animGameObject, AnimationCurve animationCurve)
    {
        float timer = 0;
        Vector3 BasicScale = animGameObject.transform.localScale;
        while (timer <= animationTime)
        {
            animGameObject.transform.localScale = animationCurve.Evaluate(timer / animationTime) * BasicScale;
            Debug.Log("time:" + timer + "  value:" + animationCurve.Evaluate(timer / animationTime) * BasicScale);
            timer += Time.deltaTime;
            yield return 0;
        }
    }
    public void UpdateScore()
    {
        scoreText.text = "Score: " + BaseControl.GetInstance().GetScore();
    }
    public void DefenderButtonDown()
    {
        PlayerControl.GetInstance().holdingDefender = true;
    }
    public void BeaconButtonDown()
    {
        PlayerControl.GetInstance().holdingBeacon = true;
    }
}