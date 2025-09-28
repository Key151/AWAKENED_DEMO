using System;
using UnityEditor;
public class AttackNormal : IAttack
{
    public void Attack(Unit attacker, Unit target)
    {
        int valorBase = 5;
        int interval = 3;
        Random r = new();
        int DanoTotal = attacker.TotalDamage() + r.Next(-interval, interval);
        target.StartCoroutine(target.TakeDamage(DanoTotal));
        attacker.CurrentActionPoint -= valorBase;

        if (attacker.CurrentActionPoint <= 0)
        {
            attacker.CurrentActionPoint = 0;
        }

        //UnityEngine.Debug.Log($"o {attacker} está atacanndo para {target} com dano de {attacker.TotalDamage()}");
    }
}