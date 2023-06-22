using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEffect : Effect
{
    private const float variance = 0.2f;
    public float power = 1;

    public override void ApplyEffect(StatSystem attacker, StatSystem defender)
    {
        float attackerScore = CalculateScore(attacker, attackStats);

        float roll = 1 + Random.Range(-variance, variance);

        float finalScore = (attackerScore * roll) * power;

        defender.ChangeHP(Mathf.CeilToInt(finalScore));
        Debug.LogFormat("{0} healed {1} amount", defender.name, Mathf.CeilToInt(finalScore));
    }
    protected override int CalculateScore(StatSystem unit, List<StatsEffect> stats)
    {
        return base.CalculateScore(unit, stats);
    }
}
