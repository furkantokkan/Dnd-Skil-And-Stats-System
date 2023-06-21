using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitChanceCalculator : MonoBehaviour
{
    public StatEnum attackerStat = StatEnum.None;

    public StatEnum defenderStat = StatEnum.None;
    public abstract bool Calculate(StatSystem attacker, StatSystem defender);
}
