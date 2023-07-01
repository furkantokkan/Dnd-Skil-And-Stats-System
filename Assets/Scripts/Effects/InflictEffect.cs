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
            ResetDuration(statusHolder);
            return;
        }

        Status status = Instantiate(statusToInflict, Vector2.zero, Quaternion.identity, statusHolder);
        status.name = status.name.Replace("(Clone)", "");
        status.SetActors(attacker, defender);   
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
    void ResetDuration(Transform statusHolder)
    {
        TemporaryStatus[] status = statusHolder.GetComponentsInChildren<TemporaryStatus>();
        foreach (TemporaryStatus statusItem in status)
        {
            if (statusItem.name == statusToInflict.name)
            {
                statusItem.currentDuration = statusItem.initalDuration;
            }
        }
    }
}
