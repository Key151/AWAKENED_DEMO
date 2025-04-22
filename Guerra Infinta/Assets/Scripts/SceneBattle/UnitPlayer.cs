using UnityEngine;

using static BattleSystem;

public class UnitPlayer : Unit, IVerificateTurnUnit
{
    public BattleState turnUnit()
    {
        return BattleState.PLAYERTURN;
    }

    public void MoveAtk(Transform enemy)
    {
        //posição de ataque
        float playerPositionX = enemy.position.x + AttackX;
        float playerPositionY = enemy.position.y + AttackY;
        this.transform.position = new Vector2(playerPositionX, playerPositionY);
    }
}