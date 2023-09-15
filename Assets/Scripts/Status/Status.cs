using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public StatusType type;

    [HideInInspector]
    public StatSystem host;

    [HideInInspector]
    public StatSystem caster;

    public void SetActors(StatSystem newCaster, StatSystem newHost)
    {
        host = newHost;
        caster = newCaster;
    }
}
