using UnityEngine;

public abstract class ApplyItem: ScriptableObject
{
    public abstract void ApplyEffect(Unit player, Unit target);
}