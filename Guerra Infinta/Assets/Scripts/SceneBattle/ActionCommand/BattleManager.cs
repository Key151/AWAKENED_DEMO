
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField]
    private ActionCommand actionCommand;


    public IEnumerator StartAttackSequence(UnitPlayer player, UnitEnemy enmey)
    {
        bool finished = false;
        bool success = false;

        Debug.Log("Iniciando ataque!");
        TriggerActionCommand(player, result =>
        {
            success = result;
            finished = true;
        }, enmey);

        // Retorna o valor final
        yield return new WaitUntil(() => finished);
    }

    public void TriggerActionCommand(UnitPlayer player, System.Action<bool> onFinished, UnitEnemy enemy)
    {
        // esse "resultado =>" é lambda, ou seja, faz a função direto no local para isso precisa do Action<> 
        actionCommand.StartActionCommand(result => 
        {
            OnActionCommandResult(result, player);
            onFinished?.Invoke(result); // repassa o booleano para quem chamou
        }, enemy);
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
