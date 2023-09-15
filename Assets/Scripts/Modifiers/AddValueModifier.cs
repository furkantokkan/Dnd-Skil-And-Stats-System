using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddValueModifier : StatModifier
{
    private ModifiedValue lastValue;
    public override void ChangeValue(ModifiedValue modifiedValue)
    {
        modifiedValue.moddedValue += value;
        lastValue = modifiedValue;
    }
    private void OnDisable()
    {
        if (lastValue != null)
        {
            lastValue.moddedValue -= value;
        }
    }
}
