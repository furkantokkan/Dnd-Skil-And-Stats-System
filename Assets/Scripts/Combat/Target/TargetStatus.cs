using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetStatus : Targets
{
    public StatusType statusType;
    public override StatSystem GetTarget()
    {
        Team team = GetTargetTeam();
        StatSystem[] units = team.GetComponentsInChildren<StatSystem>();

        if (units.Length <= 0)
        {
            Debug.LogError("Team is Empty");
            return null;
        }

        StatSystem value = null;

        foreach (StatSystem unit in units)
        {
            Status[] status = unit.transform.Find("Status").GetComponentsInChildren<Status>();

            if (SearchRemoveables(status))
            {
                value = unit;
            }

        }

        return value;
    }

    private bool SearchRemoveables(Status[] status)
    {
        foreach (Status item in status)
        {
            if (item.type == statusType)
            {
                return true;
            }
        }

        return false;
    }

    private Team GetTargetTeam()
    {
        Team thisTeam = GetComponentInParent<Team>();

        if (statusType == StatusType.Debuff)
        {
            return thisTeam;
        }
        else
        {
            return thisTeam.enemyTeam;
        }
    }
}
