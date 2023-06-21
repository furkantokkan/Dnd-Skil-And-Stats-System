using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitChanceCalculator : MonoBehaviour
{
    public abstract bool Calculate(StatSystem attacker, StatSystem defender);
}
