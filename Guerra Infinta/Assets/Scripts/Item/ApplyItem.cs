using UnityEngine;

public abstract class ApplyItem : Item
{
    public TypeBattle typeBattle;
    public abstract void ApplyEffect(Unit player, Unit target);
}