using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ParaDefine : SingletonMono<ParaDefine>
{
    [Serializable]
    public class litColorSetting
    {
        public litColorSetting(Color _color, float _idensity)
        {
            this.color = _color;
            this.idensity = _idensity;
        }
        public Color color;
        public float idensity;
    }
    public litColorSetting signDisableColor, signEnableColor;
}