using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BattleSystem;

public class BattleEnemy
{
    BattleSystem BattleSystem;

    public void SystemEnemyBattle(UnitEnemy enemy, UnitPlayer player)
    {
        BattleSystem = GameObject.Find("BattleSystem").GetComponent<BattleSystem>();

        if (Random.Range(0, 10) >= 3)
        {
            enemy.Attack(player);
            player.takingDamage = true;
            BattleSystem.dialogueText.text = enemy.UnitName + " ataca\n" + player.UnitName + "!";
            player.takingDamage = false;
        }
        
        else
        {
            BattleSystem.dialogueText.text = enemy.UnitName + " se cura" + "!";
        }
    }
}