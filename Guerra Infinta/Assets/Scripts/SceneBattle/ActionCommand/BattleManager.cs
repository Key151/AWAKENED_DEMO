
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField]
    private ActionCommand actionCommand;

    public void StartAttackSequence(UnitPlayer player)
    {
        Debug.Log("Iniciando ataque!");
        TriggerActionCommand(player);
    }

    public void TriggerActionCommand(UnitPlayer player)
    {
        actionCommand.StartActionCommand(success => OnActionCommandResult(success, player));
    }

    public void OnActionCommandResult(bool success, UnitPlayer unitPlayer)
    {
        if (success)
        {
            unitPlayer.DamageBonus += 10; // Exemplo de bônus de dano
            Debug.Log("Ataque Crítico!");
        }
        else
        {
            Debug.Log("Ataque normal.");
        }
    }
}
