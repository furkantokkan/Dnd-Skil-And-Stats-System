using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitChanceFixed: HitChanceCalculator
{
    public float value = 70;

    public override bool Calculate(StatSystem attacker, StatSystem defender)
    {
        int roll = Random.Range(0, 101);

        if (roll > value)
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
