using UnityEngine;

public abstract class ApplyItem : Item
{
    public abstract void ApplyEffect(Unit player, Unit target);
}