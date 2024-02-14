using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderLightControl : MonoBehaviour
{

    Renderer CurrentRenderer;
    Color CurrentLitColor, TargetLitColor;
    public void ChangeSignLightColor(int childId, bool enabled)
    {
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
        while (cnt < 20)
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
