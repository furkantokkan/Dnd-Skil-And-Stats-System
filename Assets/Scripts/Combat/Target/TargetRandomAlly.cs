using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRandomAlly : Targets
{
    public override StatSystem GetTarget()
    {
        Team team = GetComponentInParent<Team>();
        StatSystem[] units = team.GetComponentsInChildren<StatSystem>();
        int roll = Random.Range(0, units.Length);
        return units[roll];
    }
}
