using UnityEngine;

public class AttackSPC : IAttackSP
{
    public void AttackSP(Unit attacker, Unit target)
    {
        Debug.Log($"o {attacker} está atacanndo com SP C para {target}");
    }
}