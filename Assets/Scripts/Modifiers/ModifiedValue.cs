using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifiedValue 
{
    public int moddedValue;

    public StatEnum type;

    public ModifiedValue(int value, StatEnum type)
    {
        moddedValue = value;
        this.type = type;
    }
}
