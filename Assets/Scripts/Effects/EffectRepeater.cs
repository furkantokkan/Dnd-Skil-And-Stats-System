using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRepeater : MonoBehaviour
{
    Status status;

    private void Start()
    {
        status = GetComponent<Status>();
        status.host.onTurnBegin += OnTurnBegin;
    }
    private void OnDisable()
    {
        if (status != null)
        {
            status.host.onTurnBegin -= OnTurnBegin;
        }
    }
    void OnTurnBegin()
    {
        foreach (Effect effect in GetComponents<Effect>())
        {
            if(status.host.GetAbilityScore(StatEnum.HP) > 0)
            {
                effect.ApplyEffect(status.caster, status.host);
            }
        }
    }
}
