
using UnityEngine;
using static BattleSystem;

public class UnitEnemy : Unit, IVerificateTurnUnit
{
    [SerializeField] private DamageText textDamage;

    public override bool CheckDead()
    {
        return base.CheckDead();
    }

    public override void TakeDamage(int damage)
    {
        textDamage.ShowDamage(damage);
        base.TakeDamage(damage);
    }

    public BattleState turnUnit()
    {
        return BattleState.ENEMYTURN;
    }
}