using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitChanceCalculator : MonoBehaviour
{
    private const float hitChanceObjective = 70;
    public static bool Calculate(StatSystem attacker, StatSystem defender)
    {
        float attackerScore = attacker.GetAbilityScore(StatEnum.Dexterity);
        float defenderScore = defender.GetAbilityScore(StatEnum.Agility);

        float score = (attackerScore - defenderScore) * 2;

        float finalScore = score + hitChanceObjective;
        float roll = Random.Range(0, 101);

        //Debug.LogFormat("Score:{0}, finalScore:{1}, roll:{2}", score, finalScore, roll);

        if (roll > finalScore)
        {
            Debug.Log("Miss");
            return false;
        }
        else
        {
            Debug.Log("Hit");
            return true;
        }
    }
}
