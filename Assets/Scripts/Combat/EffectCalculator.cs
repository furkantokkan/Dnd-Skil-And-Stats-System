using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EffectCalculator : MonoBehaviour
{
    private const float variance = 0.2f;

    public static void ApplyEffect(StatSystem attacker, StatSystem defender)
    {
        float attackerScore = attacker.GetAbilityScore(StatEnum.Strength);
        float defenderScore = defender.GetAbilityScore(StatEnum.Constitution);

        float score = attackerScore - (defenderScore / 2);
        float roll = Random.Range(-variance, variance);

        float finalScore = score * roll;

        Debug.LogFormat("Attacker Score:{0}, DefenderScore{1}, roll:{3}, finalScore:{4}", attackerScore, defenderScore, score, roll, finalScore);

        defender.TakeDamage(Mathf.CeilToInt(finalScore));
        Debug.LogFormat("{0} suffered {1} damage", defender.name, Mathf.CeilToInt(finalScore));
    }
}
