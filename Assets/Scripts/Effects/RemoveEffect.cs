using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveEffect : Effect
{
    public StatusType targetType = StatusType.Buff;
    public override void ApplyEffect(StatSystem attacker, StatSystem defender)
    {
        Transform statusHolder = defender.transform.Find("Status");

        Status[] removeTargets = statusHolder.GetComponentsInChildren<Status>();

        if (removeTargets.Length > 0)
        {
            foreach (Status target in removeTargets)
            {
                if (target.type == targetType)
                {
                    Destroy(target.gameObject);
                }
            }
        }
    }
}
