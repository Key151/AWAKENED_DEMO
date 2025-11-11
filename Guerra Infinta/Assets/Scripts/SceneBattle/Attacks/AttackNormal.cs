using System;
using UnityEditor;
using UnityEngine;
public class AttackNormal : IAttack
{
    public void Attack(Unit attacker, Unit target)
    {
        int valorBase = 12+(target.Spd/attacker.Spd); //Cursto de AP
        int interval = attacker.TotalDamage() * 10/100;
        int maxAP = 100;
        UnityEngine.Debug.Log($"[TESTE] {attacker.TotalDamage()} está atacanndo para {interval}");

        System.Random r = new();
        int DanoTotal = attacker.TotalDamage() + r.Next(-interval, interval);

        target.StartCoroutine(target.TakeDamage(DanoTotal));

        attacker.CurrentActionPoint -= valorBase;
        attacker.CurrentActionPoint = Mathf.Clamp(attacker.CurrentActionPoint, 0, maxAP);

        UnityEngine.Debug.Log($"o {attacker} está atacanndo para {target} com dano de {attacker.TotalDamage()} e AP é {attacker.CurrentActionPoint}");
    }
}