using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelf : Targets
{
    public override StatSystem GetTarget()
    {
        return GetComponentInParent<StatSystem>();
    }
}
