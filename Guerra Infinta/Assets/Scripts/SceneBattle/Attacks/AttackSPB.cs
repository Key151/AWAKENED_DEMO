using UnityEngine;
public class AttackSPB : IAttackSP
{
    public void AttackSP(Unit attacker, Unit target)
    {
        Debug.Log($"o {attacker} está atacanndo com SP B para {target}");

    }

}