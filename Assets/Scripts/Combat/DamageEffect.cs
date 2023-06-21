using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : EffectCalculator
{
    private const float variance = 0.2f;

    public override void ApplyEffect(StatSystem attacker, StatSystem defender)
    {
        float attackerScore = CalculateScore(attacker, attackStats);
        float defenderScore = defender.GetAbilityScore(defenderStat);

        float score = attackerScore - (defenderScore / 2);
        float roll = 1 + Random.Range(-variance, variance);

        float finalScore = score * roll;

        Debug.LogFormat("Attacker Score:{0}, DefenderScore{1}, roll:{3}, finalScore:{4}", attackerScore, defenderScore, score, roll, finalScore);
        int negativeScore = Mathf.CeilToInt(Mathf.Abs(finalScore) * (-1));
        defender.ChangeHP(negativeScore);
        Debug.LogFormat("{0} suffered {1} damage", defender.name, negativeScore);
    }
    protected override int CalculateScore(StatSystem unit, List<StatsEffect> stats)
    {
        return base.CalculateScore(unit, stats);
    }
}
