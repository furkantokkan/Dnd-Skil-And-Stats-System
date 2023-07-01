using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryStatus : Status
{
    public int initalDuration;

    public int currentDuration;

    StatSystem host;

    private void Awake()
    {
        host = GetComponentInParent<StatSystem>();
    }
    private void OnEnable()
    {
        currentDuration = initalDuration;
        if (host != null )
        {
            host.onTurnBegin += OnTurnBegin;
        }
    }
    private void OnDisable()
    {
        if (host != null)
        {
            host.onTurnBegin -= OnTurnBegin;
        }
    }

    void OnTurnBegin()
    {
        currentDuration--;

        if (currentDuration <= 0)
        {
            Destroy(gameObject);
        }
    }
}
