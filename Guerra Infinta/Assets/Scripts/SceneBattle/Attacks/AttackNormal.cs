using Unity.VisualScripting;

public class AttackNormal : IAttack
{
    public void Attack(Unit attacker, Unit target)
    {
        //caso der false, significa que não deu para executar o dano
        bool isDead = target.TakeDamage(attacker.Damage);

        if (isDead)
        {
            target.CurrentHP = 0;
            target.Dead = true;
        }
    }
}
