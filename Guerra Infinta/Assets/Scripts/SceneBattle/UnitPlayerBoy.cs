using System.Collections.Generic;
using UnityEngine;

public class UnitPlayerBoy : Unit
{
    // ou private List<IAtaque>() ataques = new List<IAtaque>();
    private Dictionary<ItemList, IAttackSP> attackSP = new Dictionary<ItemList, IAttackSP>();

    public UnitPlayerBoy()
    {
        Debug.Log("UnitPlayerBoy tudo certo!");
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

    public void MoveAtk(Transform enemy)
    {
        //posição de ataque
        float playerPositionX = enemy.position.x + AttackX;
        float playerPositionY = enemy.position.y + AttackY;
        this.transform.position = new Vector2(playerPositionX, playerPositionY);
    }

}