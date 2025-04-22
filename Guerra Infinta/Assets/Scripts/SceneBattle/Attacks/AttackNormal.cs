public class AttackNormal : IAttack
{
    public void Attack(Unit attacker, Unit target)
    {
        int valorBase = 20;

        target.TakeDamage(attacker.Damage);

        attacker.CurrentActionPoint -= valorBase;
        if (attacker.CurrentActionPoint <= 0)
        {
            attacker.CurrentActionPoint = 0;
        }

        UnityEngine.Debug.Log($"o {attacker} está atacanndo para {target} com dano de {attacker.Damage}");
    }
}