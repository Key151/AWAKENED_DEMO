using System;
using UnityEditor;
using UnityEngine;
public class AttackNormal : IAttack
{
    public void Attack(Unit attacker, Unit target)
    {
        int valorBase = 12+(target.Spd/attacker.Spd); //Cursto de AP
        int interval = attacker.TotalDamage() * 10/100;
        int maxAP = attacker.MaxActionPoint;
        UnityEngine.Debug.Log($"[TESTE] {valorBase}; {target.Spd / attacker.Spd}");

        System.Random r = new();
        int DanoTotal = attacker.TotalDamage() + r.Next(-interval, interval);

        target.StartCoroutine(target.TakeDamage(DanoTotal));

        attacker.CurrentActionPoint -= valorBase;

        UnityEngine.Debug.Log($"o {attacker} está atacanndo para {target} com dano de {attacker.TotalDamage()} e AP é {attacker.CurrentActionPoint}");
    }
}