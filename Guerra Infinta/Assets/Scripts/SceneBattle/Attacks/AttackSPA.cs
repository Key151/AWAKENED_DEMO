using UnityEngine;
public class AttackSPA : IAttackSP
{
    public void AttackSP(Unit attacker, Unit target )
    {
        Debug.Log($"o {attacker} está atacanndo com SP A para {target}");
    }
}
