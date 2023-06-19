using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiValueModifier : StatModifier
{
    private ModifiedValue lastValue;

    public StatEnum typeToEffect;
    public override void ChangeValue(ModifiedValue modifiedValue)
    {
        if (modifiedValue.type == typeToEffect)
        {
            modifiedValue.moddedValue += value;
            lastValue = modifiedValue;
        }
    }
    private void OnDisable()
    {
        if (typeToEffect == lastValue.type)
        {
            lastValue.moddedValue -= value;
        }
    }
}
