using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.UIElements.ToolbarMenu;

public class PercentageEffect : Effect
{
    [Tooltip("Use negative for damage")]
    public float power;
    public override void ApplyEffect(StatSystem attacker, StatSystem defender)
    {
        float maxHP = defender.GetAbilityScore(StatEnum.MaxHP);

        float finalScore = maxHP * (power / 100);

        defender.ChangeHP(Mathf.CeilToInt(finalScore));
    }
}
