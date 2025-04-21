
using static BattleSystem;

public class UnitPlayer : Unit, IVerificateTurnUnit
{
    public BattleState turnUnit()
    {
        return BattleState.PLAYERTURN;
    }
}