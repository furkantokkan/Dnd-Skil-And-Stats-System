using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSystem : MonoBehaviour
{
    public Stat[] stats = new Stat[Enum.GetValues(typeof(StatEnum)).Length];
    [ContextMenu("SetStats")]
    void SetStats()
    {
        for (int i = 0; i < stats.Length; i++)
        {
            stats[i].type = (StatEnum)i;
        }
    }
    [ContextMenu("RandomizeStats")]
    void RandomizeStats()
    {
        for (int i = 0; i < stats.Length; i++)
        {
            stats[i].value = UnityEngine.Random.Range(1, 20);
        }

        GetStat(StatEnum.HP).value = GetStat(StatEnum.MaxHP).value;
        GetStat(StatEnum.MP).value = GetStat(StatEnum.MaxMP).value;

    }

    public int GetAbilityScore(StatEnum type)
    {
        Stat stat = GetStat(type);

        ModifiedValue modifiedValue = new ModifiedValue(stat.value, type);

        foreach (StatModifier item in GetComponentsInChildren<StatModifier>())
        {
            if (type == item.type)
            {
                item.ChangeValue(modifiedValue);
            }
        }

        //int score = (modifiedValue.moddedValue - 10) / 2;

        return modifiedValue.moddedValue;
    }

    public void TakeDamage(int damage)
    {
        Stat hp = GetStat(StatEnum.HP);
        int clampedValue = Mathf.Clamp(damage, 0, hp.value);
        hp.value -= clampedValue;
    }

    public Stat GetStat(StatEnum type)
    {
        return stats[(int)type];
    }
}
