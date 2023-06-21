using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    StatSystem attacker;

    private void Awake()
    {
        attacker = GetComponentInParent<StatSystem>();
    }

    public void Use(StatSystem defender)
    {
        if (GetComponent<HitChanceCalculator>().Calculate(attacker, defender))
        {
            GetComponent<EffectCalculator>().ApplyEffect(attacker, defender);
        }
    }
}
