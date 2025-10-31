using UnityEngine;

public class BattleEnemy
{
    BattleSystem BattleSystem;

    public void SystemEnemyBattle(UnitEnemy enemy, UnitPlayer player)
    {
        BattleSystem = GameObject.Find("BattleSystem").GetComponent<BattleSystem>();

        if (Random.Range(0, 10) >= 3)
        {
            enemy.Attack(player);
            player.TakingDamage = true;
            BattleSystem.dialogueText.text = enemy.UnitName + " ataca\n" + player.UnitName + "!";
            player.TakingDamage = false;
        }
        
        else
        {
            BattleSystem.dialogueText.text = enemy.UnitName + " se cura" + "!";
        }
    }
}