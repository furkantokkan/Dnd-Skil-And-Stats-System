using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InflictEffect : Effect
{
    public Status statusToInflict;

    public bool stacks = false;

    public override void ApplyEffect(StatSystem attacker, StatSystem defender)
    {
        Transform statusHolder = defender.transform.Find("Status");
        if(!CanApply(statusHolder))
        {
            Debug.Log("Couldn't apply");
            return;
        }

        Status status = Instantiate(statusToInflict, Vector2.zero, Quaternion.identity, statusHolder);
        status.name = status.name.Replace("(Clone)", "");
    }

    bool CanApply(Transform statusHolder)
    {
        if (stacks)
        {
            return true;
        }

        for (int i = 0; i < statusHolder.childCount; i++)
        {
            if (statusHolder.GetChild(i).name == statusToInflict.name)
            {
                return false;
            }
        }

        return true;
    }
}
