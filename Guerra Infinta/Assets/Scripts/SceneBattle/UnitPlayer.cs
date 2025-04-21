
public class UnitPlayer : Unit, IVerificateTurnUnit
{
    public EnumUnit turnUnit()
    {
        return EnumUnit.Player;
    }
}