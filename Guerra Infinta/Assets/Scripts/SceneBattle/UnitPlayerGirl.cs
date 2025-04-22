using System.Collections.Generic;
using UnityEngine;

public class UnitPlayerGirl : UnitPlayer
{
    // ou private List<IAtaque>() ataques = new List<IAtaque>();
    private readonly Dictionary<ItemList, IAttackSP> attackSP = new Dictionary<ItemList, IAttackSP>();

    public UnitPlayerGirl()
    {
        Debug.Log("UnitPlayerGirl tudo certo!");
    }

    public void AttackingSP(Unit target, ItemList item)
    {
        if (attackSP.ContainsKey(item)) {
            attackSP[item].AttackSP(this, target);
        }
        else
        {
            Debug.Log($"Ataque não encontrado: {item}");
        }
    }

    public void UnlockAttack(ItemList item, IAttackSP ataque)
    {
        //verifica se o ataque já existe
        if (!attackSP.ContainsKey(item))
        {
            attackSP.Add(item, ataque);
            Debug.Log($"Novo ataque desbloqueado: {item}!");
        }
    }

}