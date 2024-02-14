using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererControl : SingletonMono<RendererControl>
{
    Renderer CurrentRenderer;
    Color litColor;
    public void LoopLightColor(Transform targetTrans, ParaDefine.LitColorSetting targetLitColor)
    {
        Debug.Log("LoopVFX" + targetTrans.ToString());
        CurrentRenderer = targetTrans.GetComponent<Renderer>();
        litColor = new Color(
            targetLitColor.color.r * Mathf.Pow(2, targetLitColor.idensity),
            targetLitColor.color.g * Mathf.Pow(2, targetLitColor.idensity),
            targetLitColor.color.b * Mathf.Pow(2, targetLitColor.idensity),
            0);
        StartCoroutine(ILoopLightColor(CurrentRenderer, litColor));
    }
    private IEnumerator ILoopLightColor(Renderer targetRenderer, Color targetLitColor)
    {
        MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
        Color litColor;
        targetRenderer.GetPropertyBlock(propertyBlock);
        litColor = propertyBlock.GetColor("_GlowColor");
        int cnt = 0;
        while (cnt < 10)
        {
            litColor *= 0.5f;
            propertyBlock.SetColor("_GlowColor", litColor);
            CurrentRenderer.SetPropertyBlock(propertyBlock);
            cnt++;
            yield return 0;
        }
        litColor = targetLitColor * Mathf.Pow(0.5f, cnt);
        propertyBlock.SetColor("_GlowColor", litColor);
        CurrentRenderer.SetPropertyBlock(propertyBlock);
        while (cnt > 0)
        {
            litColor *= 2;
            propertyBlock.SetColor("_GlowColor", litColor);
            CurrentRenderer.SetPropertyBlock(propertyBlock);
            cnt--;
            yield return 0;
        }
    }
}
