using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnOrderController : MonoBehaviour
{
    [Header("Player Team")]
    public Team playerTeam;

    public List<StatSystem> playerUnits;

    [Space]

    [Header("Enemy Team")]
    public Team enemyTeam;

    public List<StatSystem> enemyUnits;

    [Space]

    [Header("Units in Attack Queue")]
    public Queue<StatSystem> units = new Queue<StatSystem>();

    private void Awake()
    {
        InitializeUnits();
    }

    private void InitializeUnits()
    {
        playerUnits = new List<StatSystem>(playerTeam.GetComponentsInChildren<StatSystem>());
        enemyUnits = new List<StatSystem>(enemyTeam.GetComponentsInChildren<StatSystem>());

        int maxUnits = Mathf.Max(playerUnits.Count, enemyUnits.Count);

        for (int i = 0; i < maxUnits; i++)
        {
            AddUnit(i, playerUnits);
            AddUnit(i, enemyUnits);
        }

        units.OrderByDescending(x => x.GetAbilityScore(StatEnum.Agility));
    }

    void AddUnit(int i, List<StatSystem> newUnits)
    {
        if (i < newUnits.Count)
        {
            units.Enqueue(newUnits[i]);
        }
    }
}
