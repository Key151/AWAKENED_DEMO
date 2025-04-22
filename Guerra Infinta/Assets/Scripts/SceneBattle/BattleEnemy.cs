using UnityEngine;

public class BattleEnemy
{
    public void SystemEnemyBattle(UnitEnemy enemy, UnitPlayer player)
    {
        if (Random.Range(0, 10) >= 3)
        {
            enemy.Attack(player);
            player.takingDamage = true;
        }
    }
}