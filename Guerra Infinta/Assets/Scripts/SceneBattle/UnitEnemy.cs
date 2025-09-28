
using System.Collections;
using UnityEngine;
using static BattleSystem;

public class UnitEnemy : Unit, IVerificateTurnUnit
{
    [SerializeField] private DamageText textDamage;

    public override bool CheckDead()
    {
        return base.CheckDead();
    }

    public override IEnumerator TakeDamage(int damage)
    {
        textDamage.ShowDamage(damage);
        StartCoroutine(base.TakeDamage(damage));
        yield return new WaitForSeconds(1f);
    }

    public BattleState turnUnit()
    {
        return BattleState.ENEMYTURN;
    }
}