using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class EffectCalculator : MonoBehaviour
{
    public abstract void ApplyEffect(StatSystem attacker, StatSystem defender);
}
