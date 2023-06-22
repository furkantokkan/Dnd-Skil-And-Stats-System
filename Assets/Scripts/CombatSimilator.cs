using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSimilator : MonoBehaviour
{
    [Header("Actors")]

    public StatSystem attacker;

    public StatSystem defender;

    [Header("Debug")]
    public StatEnum statToPrint;
    [ContextMenu("Print Stat")]
    void PrintStat()
    {
        Debug.LogFormat("Value:{0}, Score:{1}",
            attacker.GetStat(statToPrint).value,
            attacker.GetAbilityScore(statToPrint));

    }
    [ContextMenu("Fight")]
    void StartFight()
    {
        StartCoroutine(FightRoutine());
    }

    private IEnumerator FightRoutine()
    {
        StatSystem lastAttacked;

        do
        {
            Debug.LogFormat("{0}'s turn", attacker.name);

            Skill skill = GetRandomSkill();
            skill.Use(skill.GetComponent<Targets>().GetTarget());

            lastAttacked = defender;
            defender = attacker;
            attacker = lastAttacked;
            yield return new WaitForSeconds(1f);

        } while (lastAttacked.GetStat(StatEnum.HP).value > 0);

        Debug.LogFormat("{0} is dead", lastAttacked.name);
    }

    [ContextMenu("AddModifier")]
    void AddModifier()
    {
        AddValueModifier mod = attacker.transform.Find("Status").gameObject.AddComponent<AddValueModifier>();
        mod.type = statToPrint;
        mod.value = ScoreTable.AbilityValueModifierToAdd(1);
    }
    [ContextMenu("MultiModifier")]
    void MultiModifier()
    {
        MultiValueModifier mod = attacker.transform.Find("Status").gameObject.AddComponent<MultiValueModifier>();
        mod.type = statToPrint;
        mod.typeToEffect = statToPrint;
        mod.value = ScoreTable.AbilityValueModifierToAdd(3);
    }
    Skill GetRandomSkill()
    {
        Skill[] skills = attacker.GetComponentsInChildren<Skill>();
        int index = Random.Range(0, skills.Length);
        return skills[index];
    }
    //void CauseDamage()
    //{
    //    int roll = Random.Range(1, 7);
    //    int score = roll + attacker.GetAbilityScore(statToPrint);

    //    defender.TakeDamage(score);

    //    Debug.LogFormat("{0} suffered {1} damage", defender.name, score);
    //}
    //bool HitChance()
    //{
    //    int roll = Random.Range(1, 21);

    //    float armorClass = defender.GetStat(StatEnum.ArmorClass).value;
    //    float score = roll + attacker.GetAbilityScore(statToPrint);

    //    Debug.LogFormat("Roll:{0} | Score:{1} | armorClass:{2}", roll, score, armorClass);

    //    if (score > armorClass)
    //    {
    //        Debug.Log("Hit");
    //        return true;
    //    }
    //    else
    //    {
    //        Debug.Log("Miss");
    //        return false;
    //    }
}
