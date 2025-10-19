
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField]
    private ActionCommand actionCommand;

    public void StartAttackSequence(UnitPlayer player, UnitEnemy unitEnemy)
    {
        Debug.Log("Iniciando ataque!");
        TriggerActionCommand(player, unitEnemy);
    }

    public void TriggerActionCommand(UnitPlayer player, UnitEnemy unitEnemy)
    {
        // esse "resultado =>" é lambda, ou seja, faz a função direto no local para isso precisa do Action<> 
        actionCommand.StartActionCommand(result => OnActionCommandResult(result, player), unitEnemy);
    }

    public void OnActionCommandResult(bool success, UnitPlayer unitPlayer)
    {
        if (success)
        {
            unitPlayer.DamageBonus += 10; // Exemplo de bonus de dano
            Debug.Log("Ataque Crítico!");
        }
        else
        {
            Debug.Log("Ataque normal.");
        }
    }
}
