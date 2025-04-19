public class AttackNormal : IAttack
{
    public void Attack(Unit attacker, Unit target)
    {
        int valorBase = 20;
        //caso der false, significa que não deu para executar o dano
        target.TakeDamage(attacker.Damage);

        attacker.CurrentActionPoint -= valorBase;
    }
}