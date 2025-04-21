
using static BattleSystem;

public class UnitEnemy : Unit, IVerificateTurnUnit
{
    public BattleState turnUnit()
    {
        return BattleState.ENEMYTURN;
    }
}