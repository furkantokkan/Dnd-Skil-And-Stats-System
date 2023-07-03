using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSimilator : MonoBehaviour
{
    private TurnOrderController turnOrderController;

    [Header("Debug")]
    public StatSystem debugCharacter;
    public StatEnum statToPrint;

    private void Awake()
    {
        turnOrderController = GetComponent<TurnOrderController>();
    }

    [ContextMenu("Print Stat")]
    void PrintStat()
    {
        Debug.LogFormat("Value:{0}, Score:{1}",
            debugCharacter.GetStat(statToPrint).value,
            debugCharacter.GetAbilityScore(statToPrint));

    }
    [ContextMenu("Fight")]
    void StartFight()
    {
        StartCoroutine(FightRoutine());
    }
    private IEnumerator FightRoutine()
    {
        do
        {
            StatSystem attacker = GetAttacker();
            Debug.LogFormat("{0}'s turn", attacker.name);

            attacker.onTurnBegin?.Invoke();
            Skill skill = GetRandomSkill(attacker);
            if (skill)
            {
                StatSystem target = skill.GetComponent<Targets>().GetTarget();

                if (target != null)
                {
                    skill.Use(target);

                    if (target.GetAbilityScore(StatEnum.HP) <= 0)
                    {
                        Destroy(target.gameObject);
                    }

                }
                else
                {
                    Debug.Log("No valid target");
                }

            }
            else
            {
                Debug.Log("Miss The turn");
            }

            turnOrderController.units.Enqueue(attacker);
            yield return new WaitForSeconds(1f);

        } while (!CheckForGameOver());

        Debug.Log("Game Over!");
    }

    private bool CheckForGameOver()
    {
        if (!IsTeamAlive(turnOrderController.playerUnits))
        {
            Debug.Log("Player Team is Dead");
            return true;
        }

        if (!IsTeamAlive(turnOrderController.enemyUnits))
        {
            Debug.Log("Enemy Team is Dead");
            return true;
        }

        return false;
    }

    private bool IsTeamAlive(List<StatSystem> units)
    {
        for (int i = 0; i < units.Count; i++)
        {
            if (units[i].GetStat(StatEnum.HP).value > 0)
            {
                return true;
            }
        }

        return false;
    }

    private StatSystem GetAttacker()
    {
        while (turnOrderController.units.Count != 0)
        {
            StatSystem attacker = turnOrderController.units.Dequeue();

            if (attacker != null)
            {
                if (attacker.GetStat(StatEnum.HP).value > 0)
                {
                    return attacker;
                }
            }
        }

        return null;
    }

    [ContextMenu("AddModifier")]
    void AddModifier()
    {
        AddValueModifier mod = debugCharacter.transform.Find("Status").gameObject.AddComponent<AddValueModifier>();
        mod.type = statToPrint;
        mod.value = ScoreTable.AbilityValueModifierToAdd(1);
    }
    [ContextMenu("MultiModifier")]
    void MultiModifier()
    {
        MultiValueModifier mod = debugCharacter.transform.Find("Status").gameObject.AddComponent<MultiValueModifier>();
        mod.type = statToPrint;
        mod.typeToEffect = statToPrint;
        mod.value = ScoreTable.AbilityValueModifierToAdd(3);
    }
    Skill GetRandomSkill(StatSystem currentAttacker)
    {
        Skill[] skills = currentAttacker.GetComponentsInChildren<Skill>();

        if (skills.Length <= 0)
        {
            return null;
        }

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
