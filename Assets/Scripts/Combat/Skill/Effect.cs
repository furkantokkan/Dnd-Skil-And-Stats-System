using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class Effect : MonoBehaviour
{
    public List<StatsEffect> attackStats = new List<StatsEffect>() { new StatsEffect()
    {
        stat = StatEnum.None,
        multipiler = 0
    }
    };

    public StatEnum defenderStat = StatEnum.None;

    public abstract void ApplyEffect(StatSystem attacker, StatSystem defender);

    protected virtual int CalculateScore(StatSystem unit, List<StatsEffect> stats)
    {
        int sum = 0;

        foreach (StatsEffect statsEffect in stats)
        {
            int score = unit.GetAbilityScore(statsEffect.stat);
            sum += (int)(score * statsEffect.multipiler);
        }

        return sum;
    }
}
