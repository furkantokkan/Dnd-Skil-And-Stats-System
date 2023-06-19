using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatModifier : MonoBehaviour
{
    public int value;

    public StatEnum type;

    public abstract void ChangeValue(ModifiedValue modifiedValue);
}
