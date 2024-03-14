using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderLightControl : MonoBehaviour
{
    GameObject entity, defender;
    Renderer CurrentRenderer;
    Color CurrentLitColor, TargetLitColor;
    public LayerMask shaderLayer;
    bool[] signLightEnabled = { false, false };
    void Start()
    {
        entity = transform.GetChild(0).gameObject;
        defender = transform.parent.parent.gameObject;
    }
    void Update()
    {
        CheckGlobalLightDirection();
        CheckLightSourceDirection();
        if (signLightEnabled[0] == false && signLightEnabled[1] == true)
            ChangeSignLightColor(true);
        if (signLightEnabled[0] == true && signLightEnabled[1] == false)
            ChangeSignLightColor(false);
        signLightEnabled[0] = signLightEnabled[1];
        signLightEnabled[1] = false;
    }
    void CheckGlobalLightDirection()
    {
        //Debug.Log("transform.pos: " + entity.transform.position);
        //Debug.Log("Globallight.pos: " + GlobalLightControl.GetInstance().transform.position);
        if (!Physics2D.Raycast(
            entity.transform.position,
            GlobalLightControl.GetInstance().transform.position - entity.transform.position,
            GlobalLightControl.GetInstance().rotateRadius * 2,
            shaderLayer))
        {
            signLightEnabled[1] = true;
        }
    }
    void CheckLightSourceDirection()
    {
        GameObject[] lightSourceList = GameObject.FindGameObjectsWithTag("LightSource");
        foreach (GameObject lightSource in lightSourceList)
        {
            if (!Physics2D.Raycast(
                entity.transform.position,
                lightSource.transform.position - entity.transform.position,
                GlobalLightControl.GetInstance().rotateRadius * 2,
                shaderLayer))
            {
                signLightEnabled[1] = true;
            }
        }
    }
    public void ChangeSignLightColor(bool enabled)
    {
        defender.GetComponent<DefenderControl>().SwitchChargingState(enabled ? 1 : -1);
        // Debug.Log(childId + "changing color to " + enabled);
        if (enabled)
        {
            LoopLightColor(
                ParaDefine.GetInstance().signDisableColor,
                ParaDefine.GetInstance().signEnableColor);
        }
        else
        {
            LoopLightColor(
                ParaDefine.GetInstance().signEnableColor,
                ParaDefine.GetInstance().signDisableColor);
        }
    }
    public void LoopLightColor(ParaDefine.LitColorSetting currentLitColor, ParaDefine.LitColorSetting targetLitColor)
    {
        CurrentRenderer = GetComponent<Renderer>();
        TargetLitColor = new Color(
            targetLitColor.color.r * Mathf.Pow(2, targetLitColor.idensity),
            targetLitColor.color.g * Mathf.Pow(2, targetLitColor.idensity),
            targetLitColor.color.b * Mathf.Pow(2, targetLitColor.idensity),
            0);
        CurrentLitColor = new Color(
            currentLitColor.color.r * Mathf.Pow(2, currentLitColor.idensity),
            currentLitColor.color.g * Mathf.Pow(2, currentLitColor.idensity),
            currentLitColor.color.b * Mathf.Pow(2, currentLitColor.idensity),
            0);
        StartCoroutine(ILoopLightColor(CurrentRenderer, CurrentLitColor, TargetLitColor));
    }
    private IEnumerator ILoopLightColor(Renderer targetRenderer, Color currentLitColor, Color targetLitColor)
    {
        MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
        Color litColor;
        targetRenderer.GetPropertyBlock(propertyBlock);
        // Debug.Log(propertyBlock);
        litColor = currentLitColor;
        // Debug.Log("LoopVFX1" + targetRenderer.ToString() + litColor.ToString());
        int cnt = 0;
        while (cnt < 1)
        {
            litColor *= 0.8f;
            propertyBlock.SetColor("_GlowColor", litColor);
            CurrentRenderer.SetPropertyBlock(propertyBlock);
            // Debug.Log("LoopVFX1" + targetRenderer.ToString() + litColor.ToString());
            cnt++;
            yield return 0;
        }
        litColor = targetLitColor * Mathf.Pow(0.8f, cnt);
        propertyBlock.SetColor("_GlowColor", litColor);
        CurrentRenderer.SetPropertyBlock(propertyBlock);
        // Debug.Log("LoopVFX1.5" + targetRenderer.ToString() + litColor.ToString());
        yield return 0;
        while (cnt > 0)
        {
            litColor *= 1.25f;
            propertyBlock.SetColor("_GlowColor", litColor);
            CurrentRenderer.SetPropertyBlock(propertyBlock);
            // Debug.Log("LoopVFX2" + targetRenderer.ToString() + litColor.ToString());
            cnt--;
            yield return 0;
        }
        yield break;
    }
}
