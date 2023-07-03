using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetsLowHpAlly : Targets
{
    public float lowHPPercentage = 25;
    public override StatSystem GetTarget()
    {
        Team team = GetComponentInParent<Team>();
        StatSystem[] units = team.GetComponentsInChildren<StatSystem>();

        if (units.Length <= 0)
        {
            Debug.LogError("Team is Empty");
            return null;
        }

        StatSystem value = null;

        foreach (StatSystem unit in units)
        {
            float maxHP = unit.GetAbilityScore(StatEnum.MaxHP);
            float HP = unit.GetAbilityScore(StatEnum.HP);

            if (HP < maxHP * (lowHPPercentage / 100))
            {
                value = unit;
            }
        }

        if (value == null)
        {
            units.OrderBy(x => x.GetAbilityScore(StatEnum.HP));
            value = units[0];
        }

        return value;
    }
}
