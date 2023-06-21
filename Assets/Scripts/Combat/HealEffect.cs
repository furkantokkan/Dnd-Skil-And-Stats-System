using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEffect : EffectCalculator
{
    private const float variance = 0.2f;
    public float power = 1;

    public override void ApplyEffect(StatSystem attacker, StatSystem defender)
    {
        float attackerScore = attacker.GetAbilityScore(StatEnum.Strength);

        float roll = 1 + Random.Range(-variance, variance);

        float finalScore = (attackerScore * roll) * power;

        defender.ChangeHP(Mathf.CeilToInt(finalScore));
        Debug.LogFormat("{0} suffered {1} damage", defender.name, Mathf.CeilToInt(finalScore));
    }
}
